using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            if (account != null)
            {
                try
                {

                    if (account.isadmin == true)
                    {
                        return View();
                    }
                    else if (account.accountGroupID == 2)
                    {

                        if (CheckPermision.Check("/Admin/Users") == 1)
                        {
                            return RedirectToAction("Index", "Users");
                        }
                        else
                        {
                            return View();
                        }

                    }
                }
                catch (Exception)
                {

                    return RedirectToAction("Index", "Home");
                }


            }
            else
                return RedirectToAction("login", "Home", new {area = ""});

            return View();

        }
    }
}