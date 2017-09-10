using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KhachSan.Models;
using System.Threading.Tasks;

namespace KhachSan.Controllers
{
    public class HomeController : Controller
    {
        KhachSanEntities db = new KhachSanEntities();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Slide = AllSliders(); 
            return View();
        }

        public List<Slider> AllSliders()
        {
            return db.Sliders.Where(x => x.active1 == 1).OrderBy(y => y.image_Path).ToList();
        }
        
         
    }
}