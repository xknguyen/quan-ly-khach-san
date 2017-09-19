using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KhachSan.Models;
using PagedList;

namespace KhachSan.Areas.Admin.Controllers
{
    public class RoomsController : Controller
    {
        private KhachSanEntities db = new KhachSanEntities();

        // GET: Admin/Rooms
        public ActionResult Index(string q, int? numDisplay, string sort, int? page)
        {

            Account account = new Account();
            account = (Account)Session["Account"];

            switch (CheckPermision.Check(account))
            {   //là admin
                case 1:
                    ViewBag.CheckAdmin = 1;
                    return CheckPer(q, numDisplay, sort, page);
                case 2:
                    ViewBag.CheckAdmin = 2;
                    //nhân viên có quyền trong danh mục loại phòng
                    return CheckPer(q, numDisplay, sort, page);
                //Khách hàng
                case 3:
                    return RedirectToAction("Index", "Home", new { area = "" });
            }
            //Chua đăng nhập

            return RedirectToAction("login", "Home", new { area = "" });
        }

        public ActionResult CheckPer(string q, int? numDisplay, string sort, int? page)
        {

            var room = from a in db.Rooms
                       select a;

            ViewBag.CurrentSort = sort;
            //search
            if (!String.IsNullOrEmpty(q))
            {
                //room = room.Where(s => s.roomName.Contains(q) || s.roomPrice.Contains(q));
                room = room.Where(s => s.roomName.Contains(q));
            }
            ViewBag.SearchName = q;
            ViewBag.SumRoom = room.Count();
            //sort
            ViewBag.NameSort = String.IsNullOrEmpty(sort) ? "name_desc" : "";
            ViewBag.DisplaySort = sort == "roomName" ? "roomName_desc" : "roomName";
            switch (sort)
            {
                case "name_desc":
                    room = room.OrderByDescending(s => s.roomName);
                    break;
                default:
                    room = room.OrderBy(s => s.roomName);
                    break;
            }
            //page
            int pageSize = 5;
            pageSize = numDisplay == 0 ? room.Count() : (numDisplay ?? 5);
            ViewBag.NumDisplay = numDisplay;
            int pageNumber = (page ?? 1);
            return View(room.ToPagedList(pageNumber, pageSize));
        }


        // GET: Admin/Rooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Admin/Rooms/Create
        public ActionResult Create()
        {
            ViewBag.categoryID = new SelectList(db.Categories, "ID", "name");
            return View();
        }

        // POST: Admin/Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( string roomName,string roomDescription,float roomPrice,int categoryID,int roomQuantily)
        {
            Room room = new Room();
            if (ModelState.IsValid)
            {
                room.roomName = roomName;
                room.roomDescription = roomDescription;
                room.roomPrice = roomPrice;
                room.categoryID = categoryID;
                room.roomQuantily = roomQuantily;
                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryID = new SelectList(db.Categories, "ID", "name", room.categoryID);
            return View(room);
        }

        // GET: Admin/Rooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryID = new SelectList(db.Categories, "ID", "name", room.categoryID);
            return View(room);
        }

        // POST: Admin/Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,roomName,roomDescription,roomPrice,categoryID,roomQuantily")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryID = new SelectList(db.Categories, "ID", "name", room.categoryID);
            return View(room);
        }
        //chức năng sửa nhanh
        public ActionResult QuickEdit(int? roomID)
        {
            var room = db.Rooms.Find(roomID);
            return View(room);
        }
        [HttpPost]
        public ActionResult QuickEdit(int roomID, string roomName, float roomPrice, int roomQuantily)
        {
            Room room = db.Rooms.Find(roomID);
            if (room != null)
            {
                room.roomName = roomName;
                room.roomPrice = roomPrice;
                room.roomQuantily = roomQuantily;
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public JsonResult SaveQuickEdit(int? id, string roomName, float roomPrice, int roomQuantily)
        {
            var room = db.Rooms.Find(id);
            if (room != null)
            {
                room.roomName = roomName;
                room.roomPrice = roomPrice;
                room.roomQuantily = roomQuantily;
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(room, JsonRequestBehavior.AllowGet);
        }
        // GET: Admin/Rooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Admin/Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
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
