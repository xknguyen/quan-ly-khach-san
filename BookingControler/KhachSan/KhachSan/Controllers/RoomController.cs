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
    public class RoomController : Controller
    {
        private KhachSanEntities db = new KhachSanEntities();
        public ActionResult ListRoom()
        {
            return View(db.Rooms.ToList());
        }
        // GET: /Room/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return RedirectToAction("Index","Home");
            }
            return View(room);
        }
        public ActionResult CreateRoomBooking()
        {
            Customer customer = new Customer();
            Booking booking = new Booking();
            BookingDetail bookingDetail = new BookingDetail();
            customer.fullName = Request.Form["fullname"];
            customer.address = Request.Form["address"];
            customer.email=Request.Form["email"];
            customer.phone = Request.Form["phone"];
            db.Customers.Add(customer);
            db.SaveChanges();

            booking.custumerID = customer.ID;
            booking.bookingStatus = false;
            booking.bookingDate = DateTime.Now;
            db.Bookings.Add(booking);
            db.SaveChanges();

            bookingDetail.bookingID=booking.ID;
            bookingDetail.roomID = Int32.Parse(Request.Form["idRoom"]);
            bookingDetail.detailQuantity = Int32.Parse(Request.Form["guest"]);
            bookingDetail.detailPrice = Double.Parse(Request.Form["priceRoom"]);
            string bookingStart = Request.Form["check-in"];
            DateTime dateStart = Convert.ToDateTime(bookingStart);
            bookingDetail.bookingStart = dateStart;
            string bookingEnd = Request.Form["check-out"];
            DateTime dateEnd = Convert.ToDateTime(bookingEnd);
            bookingDetail.bookingEnd = dateEnd;
            bookingDetail.typeRoom = Request.Form["type"];
            bookingDetail.roomQuantity = Int32.Parse(Request.Form["roomQuantity"]);
            db.BookingDetails.Add(bookingDetail);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
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
