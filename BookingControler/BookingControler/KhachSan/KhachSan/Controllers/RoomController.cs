using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KhachSan.Models;
using System.Net.Mail;

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
            string bookingStart = Request.Form["checkin"];
            DateTime dateStart = Convert.ToDateTime(bookingStart);
            bookingDetail.bookingStart = dateStart;
            string bookingEnd = Request.Form["checkout"];
            DateTime dateEnd = Convert.ToDateTime(bookingEnd);
            bookingDetail.bookingEnd = dateEnd;
            bookingDetail.typeRoom = Request.Form["type"];
            bookingDetail.roomQuantity = Int32.Parse(Request.Form["roomQuantity"]);
            db.BookingDetails.Add(bookingDetail);
            db.SaveChanges();
            //send mail
            MailMessage mailMessage = new MailMessage();
            //Mail Cua Admin
            mailMessage.To.Add("duynamctk37@gmail.com");
            mailMessage.From = new MailAddress("chodiencho@gmail.com");
            mailMessage.Subject = "[KHÁCH HÀNG ĐẶT PHÒNG]";
            mailMessage.Body = "<h1>THÔNG TIN ĐẶT PHÒNG</h1>" + "<hr/>" +
                                "<table border='1' style='border-collapse:collapse;'><thead>" +
                                "<tr><th>Họ tên</th><th>Số điện thoại</th><th>Ngày Đặt</th><th>Số phòng</th><th>Số Người</th></tr></thead>" +
                                "<tbody><tr>" + "<td>" + customer.fullName + "</td>" +
                                "<td>" + customer.phone + "</td>" +
                                "<td>" + booking.bookingDate + "</td>" +
                                "<td>" + bookingDetail.roomQuantity + "</td>" +
                                "<td>" + bookingDetail.detailQuantity + "</td>" +
                                "</tr></tbody></table>";
            mailMessage.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = true;
            //Tao 1 cai mail de gui ve Mail cua Admin
            smtpClient.Credentials = new System.Net.NetworkCredential("chodiencho@gmail.com", "nhincaigi");
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
            TempData["notice"] = "Thành Công ! Đặt phòng thành công !";
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
