using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhachSan.Models;
namespace KhachSan.Controllers
{
    public class HomeController : Controller
    {
        KhachSanEntities db = new KhachSanEntities();
        public ActionResult Index()
        {

            return View(db.Rooms.ToList());
        }

        [HttpPost]
        public ActionResult CreateBooking()
        {

            Customer customer = new Customer();
            Booking booking = new Booking();
            BookingDetail bookingDetail = new BookingDetail();
            customer.fullName = Request.Form["cusFullname"];
            customer.phone = Request.Form["cusPhone"];
            bookingDetail.detailQuantity = Int32.Parse(Request.Form["detailQuantity"]);
            string bookingStart = Request.Form["bookingStart"];
            string bookingEnd = Request.Form["bookingEnd"];
            bookingDetail.typeRoom = Request.Form["typeRoom"];
            bookingDetail.roomQuantity = Int32.Parse(Request.Form["roomQuantity"]);
            if (customer.fullName == "" || customer.phone == "" || bookingDetail.detailQuantity < 0 || bookingStart == "" || bookingEnd == "" || bookingDetail.typeRoom == "")
            {
                TempData["notice"] = "Thất Bại! Vui lòng nhập đủ thông tin";
            }
            else
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                booking.custumerID = customer.ID;
                booking.bookingStatus = false;
                booking.bookingDate = DateTime.Now;
                db.Bookings.Add(booking);
                db.SaveChanges();
                bookingDetail.bookingID = booking.ID;
                DateTime dateStart = Convert.ToDateTime(bookingStart);
                bookingDetail.bookingStart = dateStart;
                DateTime dateEnd = Convert.ToDateTime(bookingEnd);
                bookingDetail.bookingEnd = dateEnd;
                db.BookingDetails.Add(bookingDetail);
                db.SaveChanges();
                TempData["notice"] = "Thành Công ! Đặt phòng thành công !";
            }
            return RedirectToAction("Index", "Home");
        }
    }
}