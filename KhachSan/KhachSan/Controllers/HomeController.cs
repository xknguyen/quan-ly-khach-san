using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhachSan.Models;
using System.Threading.Tasks;
using System.Web.Management;
using System.Web.Services.Description;

namespace KhachSan.Controllers
{
    public class HomeController : Controller
    {

        KhachSanEntities db = new KhachSanEntities();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Slider = AllSliders();
            Account account = new Account();
            account = (Account)Session["Account"];
            //Kiểm tra đăng nhập
            if (account != null)
            {
                //là admin
                if (account.isadmin == true)
                {
                    //gán ==1 để so sánh bên view
                    ViewBag.CheckAdmin = 1;
                   
                }
            }
            else
            {
                //chưa đăng nhập thì hiển thị trang chủ
                ViewBag.CheckAdmin = 3;
                return View();
            }

            
            return View();




        }

        public List<Slider> AllSliders()
        {
            return db.Sliders.Where(x => x.active == 1).OrderBy(y => y.image_Path).ToList();
        }
        public ActionResult login()
        {

            return View();
        }
        //kiem tra thuoc nhom nao
        //public int CheckAdmin()
        //{
        //    //Account account = new Account();
        //    //account = (Account)Session["Account"];
        //   var res = from a in db.Accounts where a.isadmin == 1 select a;
        //    return res;
        //}
        //hàm đăng nhập vào website
        [HttpPost]
        public ActionResult login(string username, string password)
        {
            var sum = username + password;
            string passwordMD5 = Common.encrypt(username + password);

            Account user =
                db.Accounts.FirstOrDefault(x => x.accountName == username && x.password == passwordMD5 && x.active== true);
            if (user != null)
            {
                Session.Add("Account", user);
                return RedirectToAction("Index");
            }
            ViewBag.error = "Đăng nhập sai hoặc bạn không có quyền truy cập";
            return View();
        }

        public ActionResult Logout()
        {
            Session["Account"] = null;

            return  RedirectToAction("Index");
        }



    }
}