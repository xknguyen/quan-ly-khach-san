using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KhachSan.Models;
using PagedList;

namespace KhachSan.Areas.Admin.Controllers
{
    public class BlogsController : Controller
    {
        private KhachSanEntities db = new KhachSanEntities();

        // GET: /Admin/Blogs/
        public ActionResult Index(string q, int? numDisplay, string sort, int? page)
        {
            var blog = from b in db.Blogs
                       select b;

            ViewBag.CurrentSort = sort;

            //search
            if (!String.IsNullOrEmpty(q))
            {
                blog = blog.Where(s => s.Name.Contains(q));
            }
            ViewBag.SearchName = q;
            ViewBag.SumBlogs = blog.Count();
            //sort
            ViewBag.NameSort = String.IsNullOrEmpty(sort) ? "name_desc" : "";
            ViewBag.ParentSort = sort == "parent" ? "parent_desc" : "parent";
            switch (sort)
            {
                case "name_desc":
                    blog = blog.OrderByDescending(s => s.Name);
                    break;
                case "parent":
                    blog = blog.OrderBy(s => s.Parent);
                    break;
                case "parent_desc":
                    blog = blog.OrderByDescending(s => s.Parent);
                    break;
                default:
                    blog = blog.OrderBy(s => s.Name);
                    break;
            }
            //page
            int pageSize = 5;
            pageSize = numDisplay == 0 ? blog.Count() : (numDisplay ?? 5);
            ViewBag.NumDisplay = numDisplay;
            int pageNumber = (page ?? 1);
            return View(blog.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Admin/Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: /Admin/Blogs/Create
        public ActionResult Create()
        {
            List<SelectListItem> selectlist = new SelectList(db.Blogs.Where(x => x.Active == true).ToList(), "ID", "Name").ToList();
            selectlist.Insert(0, new SelectListItem
            {
                Selected = true,
                Text = "",
                Value = null
            });
            ViewBag.Parent = selectlist.ToList();

            return View();
        }

        // POST: /Admin/Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Parent,Order,Active")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blog);
        }

        // GET: /Admin/Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            List<SelectListItem> selectlist = new SelectList(db.Blogs.Where(x => x.Active == true).ToList(), "ID", "Name").ToList();
            selectlist.Insert(0, new SelectListItem
            {
                Selected = true,
                Text = "",
                Value = null
            });
            ViewBag.Parent = selectlist.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: /Admin/Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Parent,Order,Active")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                Blog change = db.Blogs.Find(blog.ID);
                change.Name = blog.Name;
                change.Parent = blog.Parent;
                change.Active = blog.Active;
                db.Entry(change).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: /Admin/Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }
        private void DeleteLoop(Blog blog)
        {
            var Blogs1 = blog.Blog1.ToList();
            for (int i = 0; i < Blogs1.Count; i++)
            {
                DeleteLoop(Blogs1[i] as Blog);
            }
            var Posts = blog.Posts.ToList();
            for (int i = 0; i < Posts.Count; i++)
            {
                Post posts = Posts[i];
                if (posts != null)
                {

                    db.Posts.Remove(posts);
                    db.SaveChanges();
                }
            }

            db.Blogs.Remove(blog);
            db.SaveChanges();
        }

        // POST: /Admin/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public string DeleteConfirmed(int? id)
        {

            try
            {
                var Blog = db.Blogs.Find(id);
                DeleteLoop(Blog);
                return "true";
            }
            catch
            {
                return "false";
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


        [NonAction]
        private List<Post> GetAllPost(Blog blog)
        {
            List<Post> listpost = blog.Posts.ToList();
            foreach (var item in blog.Blog1)
            {
                listpost.AddRange(GetAllPost(item));
            }
            return listpost;
        }

        private IEnumerable<Post> GetAllPost(object item)
        {
            throw new NotImplementedException();
        }
        //GET: //Blogs/Name-Blog
        public ActionResult ViewBlogs(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Blog blog = db.Blogs.FirstOrDefault(x => x.ID == id);

            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.NameBlogs = blog.Name;
            var listPost = GetAllPost(blog).OrderByDescending(x => x.Created).Distinct().ToList();
            //string titleEncode = UrlEncode.ToFriendlyUrl(wa_blogs.Name);
            return View(listPost);
        }

        public ActionResult QuickEdit(int? blogID)
        {
            ViewBag.Parent = new SelectList(db.Blogs.Where(x => x.Active == true).ToList(), "ID", "Name");
            var blog = db.Blogs.Find(blogID);
            return View(blog);
        }

        [HttpPost]
        public ActionResult QuickEdit([Bind(Include = "ID,Name,Parent,Order")] Blog blog, HttpPostedFileBase filebase)
        {

            if (ModelState.IsValid)
            {
                Blog change = db.Blogs.Find(blog.ID);
                change.Name = blog.Name;
                change.Parent = blog.Parent;
                change.Order = blog.Order;

                db.Entry(change).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);

        }


        public string SaveQuickEdit(int? id, string name, int? parent, int? order, string active)
        {
            bool Active = !String.IsNullOrEmpty(active);
            var blog = db.Blogs.Find(id);
            if (blog != null)
            {
                blog.Name = name;
                blog.Parent = parent;
                blog.Order = order;
                blog.Active = Active;
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
            }
            if (blog != null)
            {
                return "Lưu thành công!";
            }
            return "Lỗi";
        }
        public string SetActive(bool active, int id)
        {
            var blog = db.Blogs.Find(id);
            blog.Active = active;
            db.Entry(blog).State = EntityState.Modified;
            return db.SaveChanges().ToString();
        }

        public int Blog1 { get; set; }
    }
}
