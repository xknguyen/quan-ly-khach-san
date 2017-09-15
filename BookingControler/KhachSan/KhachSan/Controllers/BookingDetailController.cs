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
    public class BookingDetailController : Controller
    {
        private KhachSanEntities db = new KhachSanEntities();

        // GET: /BookingDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            BookingDetail bookingDetail = db.BookingDetails.Where(x => x.bookingID == booking.ID).FirstOrDefault();

            if (bookingDetail == null)
            {
                return HttpNotFound();
            }
            return View(bookingDetail);
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
