using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using KhachSan.Models;
using PagedList;

namespace KhachSan.Areas.Admin.Controllers
{
    using System.IO;
    public class CategoriesController : Controller
    {
        private KhachSanEntities db = new KhachSanEntities();

        // GET: Admin/Categories
        public ActionResult Index(string q, int? numDisplay, string sort, int? page)
        {
            Account account = new Account();
            account = (Account)Session["Account"];
            
            switch (CheckPermision.Check(account))
            {   //là admin
                case 1:
                  return  Quyen(q, numDisplay, sort, page);
                case 2:
                    //nhân viên có quyền trong danh mục loại phòng
                    return  Quyen(q, numDisplay, sort, page);
                //Khách hàng
                case 3:
                    return RedirectToAction("Index", "Home", new { area = "" });
            }
            //Chua đăng nhập

                    return RedirectToAction("login", "Home", new { area = "" });
        }

        public ActionResult Quyen(string q, int? numDisplay, string sort, int? page)

        {
            var category = from a in db.Categories
                           select a;

            ViewBag.CurrentSort = sort;
            //search
            if (!String.IsNullOrEmpty(q))
            {
                //room = room.Where(s => s.roomName.Contains(q) || s.roomPrice.Contains(q));
                category = category.Where(s => s.name.Contains(q));
            }
            ViewBag.SearchName = q;
            ViewBag.SumRoom = category.Count();
            //sort
            ViewBag.NameSort = String.IsNullOrEmpty(sort) ? "name_desc" : "";
            ViewBag.DisplaySort = sort == "roomName" ? "roomName_desc" : "roomName";
            switch (sort)
            {
                case "name_desc":
                    category = category.OrderByDescending(s => s.name);
                    break;
                default:
                    category = category.OrderBy(s => s.name);
                    break;
            }
            //page
            int pageSize = 5;
            pageSize = numDisplay == 0 ? category.Count() : (numDisplay ?? 5);
            ViewBag.NumDisplay = numDisplay;
            int pageNumber = (page ?? 1);
            return View(category.ToPagedList(pageNumber, pageSize));
        }



        // GET: Admin/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string name,string description, HttpPostedFileBase image)
        {
            //lay ten file
            var fileName = Path.GetFileName(image.FileName);
            //lưu hình vào folder 
            var path = Path.Combine(Server.MapPath("~/Content/images/RoomCategory"), fileName);

            //Lưu đường dẫn vào db
            var fileNew = "/Content/images/RoomCategory/" + fileName;
            if (ModelState.IsValid)
            {
                var category = new Category { name = name, description = description, image = fileNew };
                db.Categories.Add(category);
                db.SaveChanges();
                image.SaveAs(path);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,string name, string description, HttpPostedFileBase image)
        {
            Category category = db.Categories.Find(id);
            //lay ten file
            //var fileName = Path.GetFileName(image.FileName);
            ////lưu hình vào folder 
            //var path = Path.Combine(Server.MapPath("~/Content/images/RoomCategory"), fileName);

            ////Lưu đường dẫn vào db
            //var fileNew = "/Content/images/RoomCategory/" + fileName;
            //if (ModelState.IsValid)
            //{
            //    var category = new Category {ID = id, name = name, description = description, image = fileNew };
            //    db.Categories.Add(category);
            //    db.SaveChanges();
            //    image.SaveAs(path);
            //    return RedirectToAction("Index");
            //}

            //return RedirectToAction("Index");
            if (category != null)
            {
                category.name = name;
                category.description = description;
                if (Request.Files.Count > 0 && !String.IsNullOrEmpty(Request.Files[0].FileName))
                {
                    //lay ten file
                    var fileName = Path.GetFileName(image.FileName);
                    ////lưu hình vào folder 
                    var path = Path.Combine(Server.MapPath("~/Content/images/RoomCategory"), fileName);
                    //kiem tra hinh da ton tai hay chua 
                    if (System.IO.File.Exists(path))
                    {
                        
                    }
                    ////Lưu đường dẫn vào db
                    var fileNew = "/Content/images/RoomCategory/" + fileName;
                    //luu vao thu muc theo duong dan path
                    image.SaveAs(path);
                    //luu vao db theo duong dan fileNew
                    category.image = fileNew;

                }
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var room = from a in db.Rooms where a.categoryID == id select a;
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
