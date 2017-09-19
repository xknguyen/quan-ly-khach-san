using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhachSan.Models;
using System.Net.Mail;
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
                //send mail
                MailMessage mailMessage = new MailMessage();
                //Mail Cua Admin
                mailMessage.To.Add("duynamctk37@gmail.com");
                mailMessage.From=new MailAddress("chodiencho@gmail.com");
                mailMessage.Subject = "[KHÁCH HÀNG ĐẶT PHÒNG]";
                mailMessage.Body = "<h1>THÔNG TIN ĐẶT PHÒNG</h1>"+"<hr/>"+
                                    "<table border='1' style='border-collapse:collapse;'><thead>" +
                                    "<tr><th>Họ tên</th><th>Số điện thoại</th><th>Ngày Đặt</th><th>Số phòng</th><th>Số Người</th></tr></thead>" +
                                    "<tbody><tr>"+"<td>"+customer.fullName+"</td>" + 
                                    "<td>"+customer.phone+"</td>" + 
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
            }
            return RedirectToAction("Index", "Home");
        }

    }
}