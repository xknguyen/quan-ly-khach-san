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
                    ViewBag.CheckAdmin = 1;
                    return View();
                //là nhân viên
                case 2:
                    ViewBag.CheckAdmin = 2;
                    return View();
                //Khách hàng
                case 3:
                    return RedirectToAction("Index", "Home", new { area = "" });
            }
            //Chua đăng nhập
            return RedirectToAction("login", "Home", new { area = "" });
        }

       
    }
}