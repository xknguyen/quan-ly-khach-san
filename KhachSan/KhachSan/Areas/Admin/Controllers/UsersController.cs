using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//using Model;
using PagedList;
//using Account = Model.MetaData.Account;
using System.Security.Cryptography;
using System.Text;
using KhachSan.Models;


namespace KhachSan.Areas.Admin.Controllers
{

    using System.IO;
    public class UsersController : Controller
    {
        private KhachSanEntities db = new KhachSanEntities();
          int check =0;
        // GET: Admin/Users
        public ActionResult Index(string q, int? numDisplay, string sort, int? page)
        {
            Account account = new Account();
            account = (Account)Session["Account"];

            switch (CheckPermision.Check(account))
            {   //là admin
                case 1:
                    check=ViewBag.CheckAdmin = 1;
                    return CheckPer(q, numDisplay, sort, page);
                case 2:
                    //nhân viên có quyền 
                    check= ViewBag.CheckAdmin = 2;
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
            var user = from a in db.Accounts
                       select a;

            ViewBag.CurrentSort = sort;

            //search
            if (!String.IsNullOrEmpty(q))
            {
                user = user.Where(s => s.accountName.Contains(q) || s.email.Contains(q));
            }
            ViewBag.SearchName = q;
            ViewBag.SumUsers = user.Count();
            //sort
            ViewBag.NameSort = String.IsNullOrEmpty(sort) ? "name_desc" : "";
            ViewBag.EmailSort = sort == "Email" ? "email_desc" : "Email";
            ViewBag.DisplaySort = sort == "DisplayName" ? "displayName_desc" : "DisplayName";
            switch (sort)
            {
                case "name_desc":
                    user = user.OrderByDescending(s => s.accountName);
                    break;
                case "Email":
                    user = user.OrderBy(s => s.email);
                    break;
                case "email_desc":
                    user = user.OrderByDescending(s => s.email);
                    break;
                default:
                    user = user.OrderBy(s => s.accountName);
                    break;
            }
            //page
            int pageSize = 5;
            pageSize = numDisplay == 0 ? user.Count() : (numDisplay ?? 5);
            ViewBag.NumDisplay = numDisplay;
            int pageNumber = (page ?? 1);
            return View(user.ToPagedList(pageNumber, pageSize));
        }


        // GET: Admin/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,accountName,email,password,displayname,created,modified,phone,address,avatar,lastLogin,IPLast,IPCreated")] Account users, HttpPostedFileBase filebase)
        {
            if (check==1)
            {

                if (ModelState.IsValid)
                {
                    if (Request.Files.Count > 0 || !String.IsNullOrEmpty(Request.Files[0].FileName))
                    {
                        string path = "~/Content/images/avatar";
                        string pathToSave = Server.MapPath(path);
                        string filename = Path.GetFileName(Request.Files[0].FileName);
                        Request.Files[0].SaveAs(Path.Combine(pathToSave, filename));
                        users.avatar = filename;
                        var username = Request.Form["accountName"];
                        var password = Request.Form["password"];
                        string passwordMD5 = Common.encrypt(username + password);
                        users.password = passwordMD5;
                        users.created = DateTime.Now;
                        db.Accounts.Add(users);
                        db.SaveChanges();
                        return RedirectToAction("Index");

                    }
                    db.Accounts.Add(users);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(users);
            }
            return RedirectToAction("Index","Admin");
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( int ID, string accountName, string email,string displayname, string avatar, HttpPostedFileBase filebase)
        {
            Account user = db.Accounts.Find(ID);
            //if (ModelState.IsValid)
            //{
            //    if (Request.Files.Count > 0 || !String.IsNullOrEmpty(Request.Files[0].FileName))
            //    {
            //        string path = "~/Content/images/avatar";
            //        string pathToSave = Server.MapPath(path);
            //        string filename = Path.GetFileName(Request.Files[0].FileName);
            //        Request.Files[0].SaveAs(Path.Combine(pathToSave, filename));
            //        user.avatar = filename;
            //        db.Entry(user).State = EntityState.Modified;
            //        db.SaveChanges();
            //        return RedirectToAction("Index");
            //    }
            //    else

            //        return RedirectToAction("Index");
            //}
            //return View(users);
            if (user != null)
            {
                user.accountName = accountName;
                user.email = email;
                //user.password = password;
                user.displayname = displayname;
                //user.created = created;
                //user.modified = datemodified;
                //user.phone = phone;
                //user.address = address;
                if (Request.Files.Count > 0 && !String.IsNullOrEmpty(Request.Files[0].FileName))
                {
                    string path = "~/Content/images/avatar";
                    string pathToSave = Server.MapPath(path);
                    string filename = Path.GetFileName(Request.Files[0].FileName);
                    Request.Files[0].SaveAs(Path.Combine(pathToSave, filename));
                    user.avatar = filename;
                }
                //user.isadmin = isAdmin;
                user.lastLogin = DateTime.Now;
                //user.IPLast = IPLast;
                //user.active = active;

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult QuickEdit(int? userID)
        {
            var user = db.Accounts.Find(userID);
            return View(user);
        }
        [HttpPost]
        public ActionResult QuickEdit(int id, string accountName, string Email, string DisplayName)
        {
            Account user = db.Accounts.Find(id);
            if (user != null)
            {
                user.accountName = accountName;
                user.email = Email;
                user.displayname = DisplayName;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public JsonResult SaveQuickEdit(int? userID, string userName, string email, string nameDisplay)
        {
            var user = db.Accounts.Find(userID);
            if (user != null)
            {
                user.accountName = userName;
                user.email = email;
                user.displayname = nameDisplay;
                user.modified = DateTime.Now;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(user, JsonRequestBehavior.AllowGet);
        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        public void Reset(int id)
        {
            Account user = db.Accounts.Find(id);
            if (user != null)
            {
                //MD5 pass = MD5.Create();
                
                user.password = Common.encrypt(user.accountName+"1");
                db.SaveChanges();
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
