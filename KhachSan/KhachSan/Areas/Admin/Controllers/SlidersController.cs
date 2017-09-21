using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KhachSan.Models;


namespace KhachSan.Areas.Admin.Controllers
{
    using System.IO;
    public class SlidersController : Controller
    {

        private KhachSanEntities db = new KhachSanEntities();

        // GET: Admin/Sliders
        public ActionResult Index()
        {
            return View(db.Sliders.ToList());
        }

        // GET: Admin/Sliders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: Admin/Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string image_Name, string image_Description, HttpPostedFileBase imagePath, int active)
        {
            
            //lay ten file
            var fileName = Path.GetFileName(imagePath.FileName);
            //lưu hình vào folder 
            var path = Path.Combine(Server.MapPath("~/Content/images/Slider"), fileName);
          
            //Lưu đường dẫn vào db
            var fileNew = "/Content/images/Slider/" + fileName;
            if (ModelState.IsValid)
            {
                var slider = new Slider { image_Name = image_Name, image_Description = image_Description, active= active ,image_Path = fileNew };
                db.Sliders.Add(slider);
                db.SaveChanges();
                imagePath.SaveAs(path);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: Admin/Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Admin/Sliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,string image_Name, string image_Description, HttpPostedFileBase imagePath, int active)
        {
            var fileName = Path.GetFileName(imagePath.FileName);
            //lưu hình vào folder 
            var path = Path.Combine(Server.MapPath("~/Content/images/Slider"), fileName);

            //Lưu đường dẫn vào db
            var fileNew = "/Content/images/Slider/" + fileName;
            if (ModelState.IsValid)
            {
                var slider= new Slider {ID=id, image_Name = image_Name, image_Description = image_Description, active = active, image_Path = fileNew };
                db.Entry(slider).State = EntityState.Modified;
                db.SaveChanges();
                imagePath.SaveAs(path);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/Sliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Admin/Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = db.Sliders.Find(id);
            db.Sliders.Remove(slider);
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
