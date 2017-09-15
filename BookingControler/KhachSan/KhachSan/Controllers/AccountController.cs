using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhachSan.Models;
namespace KhachSan.Controllers
{
    public class AccountController : Controller
    {
        KhachSanEntities db = new KhachSanEntities();
        // GET: /Account/
        public ActionResult Login(string username,string password)
        {
            if (Session["Account"] != null)
            {
                return RedirectToAction("Index", "Booking");
            }
                Account user = db.Accounts.FirstOrDefault(x => x.accountName == username && x.password == password);
                if (user != null)
                {
                    Session.Add("Account", user);
                    user.lastLogin = DateTime.Now;
                    db.Accounts.Attach(user);
                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index","Booking");
                }

                return View();
        }

        //
        // GET: /Account/Details/5
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Account/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
