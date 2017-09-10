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
    public class FrontEndBookingsController : Controller
    {
        private KhachSanEntities db = new KhachSanEntities();

        // GET: FrontEndBookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Customer);
            return View(bookings.ToList());
        }

        // GET: FrontEndBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: FrontEndBookings/Create
        public ActionResult Create()
        {
            ViewBag.custumerID = new SelectList(db.Customers, "ID", "fullName");
            return View();
        }

        // POST: FrontEndBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int custumerID, DateTime bookingDate,int bookingStatus )
        {
            if (ModelState.IsValid)
            {
                var booking = new Booking {};
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           
            return View();
        }

        // GET: FrontEndBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.custumerID = new SelectList(db.Customers, "ID", "fullName", booking.custumerID);
            return View(booking);
        }

        // POST: FrontEndBookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,custumerID,bookingDate,bookingStatus")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.custumerID = new SelectList(db.Customers, "ID", "fullName", booking.custumerID);
            return View(booking);
        }

        // GET: FrontEndBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: FrontEndBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
