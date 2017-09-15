using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using KhachSan.Models;

namespace KhachSan.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private KhachSanEntities db = new KhachSanEntities();
        // GET: Admin/Home

        public ActionResult Index()
        {
            Account account = new Account();
            account = (Account)Session["Account"];
            switch (CheckPermision.Check(account))
            {   //là admin
                case 1:
                    return View();
                //là nhân viên
                case 2:
                    return RedirectToAction("ViewNhanVien", "Admin");
                //Khách hàng
                case 3:
                    return RedirectToAction("Index", "Home", new { area = "" });
            }
            //Chua đăng nhập
            return RedirectToAction("login", "Home", new { area = "" });
        }

        public ActionResult ViewNhanVien(string permision)
        {
            return View();

        }
    }
}