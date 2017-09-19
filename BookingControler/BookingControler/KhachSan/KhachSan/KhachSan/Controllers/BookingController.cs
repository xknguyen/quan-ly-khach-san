using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KhachSan.Models;

namespace KhachSan.Controllers
{
    public class BookingController : Controller
    {
        private KhachSanEntities db = new KhachSanEntities();

        // GET: /Booking/
        public ActionResult Index()
        {
            if (Session["Account"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var bookings = db.Bookings.Include(b => b.Customer);
                return View(bookings.ToList());
            }
        }
        public JsonResult Changestatus(int id, bool status)
        {
            Booking booking = db.Bookings.Find(id);
            if (booking != null)
            {
                booking.bookingStatus = status;
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return Json(true,JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            Booking booking = db.Bookings.Find(id);
            List <BookingDetail> bookingDetail = db.BookingDetails.Where(x => x.bookingID == booking.ID).ToList();
            Customer customer = db.Customers.Find(booking.custumerID);
            if (booking != null)
            {
                foreach (var item in bookingDetail)
                {
                    db.BookingDetails.Remove(item);
                }
                db.Bookings.Remove(booking);
                db.Customers.Remove(customer);
                db.SaveChanges();
                TempData["deleteSuccess"] = "Bạn đã xóa thành công";
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else {
                TempData["deleteFail"] = "Xóa không thành công";
                return Json(false, JsonRequestBehavior.AllowGet);
            }
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
