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
    using System.IO;
    public class PostsController : Controller
    {
        private KhachSanEntities db = new KhachSanEntities();

        // GET: /Admin/Posts/
        public ActionResult Index(string q, int? numDisplay, string sort, int? page)
        {
            var post = from p in db.Posts
                       select p;

            ViewBag.CurrentSort = sort;

            //search
            if (!String.IsNullOrEmpty(q))
            {
                post = post.Where(s => s.Title.Contains(q));
            }
            ViewBag.SearchName = q;
            ViewBag.SumPost = post.Count();
            //sort
            ViewBag.NameSort = String.IsNullOrEmpty(sort) ? "title_desc" : "";
            ViewBag.EmailSort = sort == "created" ? "created_desc" : "created";
            ViewBag.DisplaySort = sort == "author" ? "author_desc" : "author";
            ViewBag.DisplaySort = sort == "active" ? "active_desc" : "active";
            switch (sort)
            {
                case "title_desc":
                    post = post.OrderByDescending(s => s.Title);
                    break;
                case "created":
                    post = post.OrderBy(s => s.Created);
                    break;
                case "created_desc":
                    post = post.OrderByDescending(s => s.Created);
                    break;
                case "author":
                    post = post.OrderBy(s => s.Author);
                    break;
                case "author_desc":
                    post = post.OrderByDescending(s => s.Author);
                    break;
                case "active":
                    post = post.OrderBy(s => s.Active);
                    break;
                case "active_desc":
                    post = post.OrderByDescending(s => s.Active);
                    break;
                default:
                    post = post.OrderBy(s => s.Title);
                    break;
            }
            //page
            int pageSize = 5;
            pageSize = numDisplay == 0 ? post.Count() : (numDisplay ?? 5);
            ViewBag.NumDisplay = numDisplay;
            int pageNumber = (page ?? 1);
            return View(post.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Admin/Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: /Admin/Posts/Create
        public ActionResult Create()
        {
            ViewBag.ListBlogs = db.Blogs.Where(x => x.Parent == null).ToList();
            ViewBag.Author = new SelectList(db.Accounts, "ID", "accountName");
            return View();
        }

        // POST: /Admin/Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,ContentPost,Author,Picture,UseDescription,Active")] Post posts, int[] blogs, HttpPostedFileBase filebase)
        {
            if (ModelState.IsValid)
            {
                if (blogs == null || blogs.Count() == 0)
                {
                    return View("Error");
                }
                posts.Created = DateTime.Now;
                posts.Active = false;
                posts.Seen = 0;

                for (int i = 0; i < blogs.Count(); i++)
                {
                    //posts.Blogs.Add(db.Blogs.Find(blogs[i]));
                }
                string path = "~/Content/images/thuvien";
                if (Request.Files[0] != null)
                {
                    string tg = DateTime.Now.ToString("ddMMyyyy_");
                    string pathToSave = Server.MapPath(path);
                    string filename = tg + Path.GetFileName(Request.Files[0].FileName);
                    posts.Picture = Path.Combine(path, filename);
                    Request.Files[0].SaveAs(Path.Combine(pathToSave, filename));
                }
                db.Posts.Add(posts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Author = new SelectList(db.Accounts, "ID", "UserName", posts.Author);
            return View(posts);
        }

        // GET: /Admin/Posts/Edit/5
        public ActionResult Edit(int? id, string title)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post posts = db.Posts.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListBlogs = db.Blogs.Where(x => x.Parent == null && x.Active).ToList();
            ViewBag.Author = new SelectList(db.Accounts, "ID", "accountName", posts.Author);
            return View(posts);
        }

        // POST: /Admin/Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,ContentPost,Picture,UseDescription,Active")] Post posts, HttpPostedFileBase filebase)
        {
            if (ModelState.IsValid)
            {
                Post change = db.Posts.Find(posts.ID);
                change.Title = posts.Title;
                change.Description = posts.Description;
                change.ContentPost = posts.ContentPost;
                change.UseDescription = posts.UseDescription;
                change.Active = posts.Active;
                string path = "~/Content/images/thuvien";
                if (!string.IsNullOrEmpty(Request.Files[0].FileName))
                {
                    string tg = DateTime.Now.ToString("ddMMyyyy_");
                    string pathToSave = Server.MapPath(path);
                    string filename = tg + Path.GetFileName(Request.Files[0].FileName);
                    posts.Picture = Path.Combine(path, filename);
                    change.Picture = posts.Picture;
                    Request.Files[0].SaveAs(Path.Combine(pathToSave, filename));
                }
                db.Entry(change).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Author = new SelectList(db.Accounts, "ID", "accountName", posts.Author);
            return View(posts);
        }

        // GET: /Posts/Delete/5
        //[AdminFilter]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post posts = db.Posts.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }
       

        // POST: /Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post posts = db.Posts.Single(n => n.ID == id);
            if (posts != null)
            {
                var blogs = posts.Blogs.ToList();
                for (int i = 0; i < blogs.Count; i++)
                {
                    Blog blog = blogs[i];
                    blog.Posts.Remove(posts);
                    db.Entry(blogs).State = EntityState.Modified;
                    db.SaveChanges();
                }
                
                db.Posts.Remove(posts);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult ViewPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post posts = db.Posts.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            posts.Seen++;
            db.Entry(posts).State = EntityState.Modified;
            db.SaveChanges();
            return View(posts);
        }
        public ActionResult QuickEdit(int id)
        {
            ViewBag.ListBlogs = db.Blogs.Where(x => x.Parent == null && x.Active).ToList();
            var post = db.Posts.FirstOrDefault(n => n.ID == id);
            return View(post);
        }
        [HttpPost]
        public ActionResult QuickEdit([Bind(Include = "ID,Title,Description,ContentPost,Active")] Post posts, int[] blogs, HttpPostedFileBase filebase)
        {

            if (ModelState.IsValid)
            {
                if (blogs == null || blogs.Count() == 0)
                    return View("Edit", posts);
                Post change = db.Posts.Find(posts.ID);
                change.Title = posts.Title;
                change.Description = posts.Description;
                change.ContentPost = posts.ContentPost;
                change.Active = posts.Active;
                //change.Blogs = new List<Blogs>();

                //Save pic
                string path = "~/Content/images/thuvien";
                if (Request.Files[0] != null)
                {
                    string tg = DateTime.Now.ToString("ddMMyyyy_");
                    string pathToSave = Server.MapPath(path);
                    string filename = tg + Path.GetFileName(Request.Files[0].FileName);
                    change.Picture = Path.Combine(path, filename);
                    Request.Files[0].SaveAs(Path.Combine(pathToSave, filename));
                }

                foreach (var item in blogs)
                {
                    //change.Blogs.Add(db.Blogs.Find(item));
                }
                db.Entry(change).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Author = new SelectList(db.AccountGroups, "ID", "accountName", posts.Author);
            return View("Edit", posts);
        }
        [HttpPost]

        public string SaveQuickEdit(int? id, string title, string description, string active, string content)
        {
            bool Active = !String.IsNullOrEmpty(active);
            var post = db.Posts.Find(id);
            if (post != null)
            {
                post.Title = title;
                post.Active = Active;
                post.Description = description;
                post.ContentPost = content.ToString();
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
            }
            if (post != null)
            {
                return "Lưu thành công!";
            }
            return "Lỗi";
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
