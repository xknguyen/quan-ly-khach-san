using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KhachSan
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "EditPost",
                url: "Admin/chinh-sua-post/{title}-{id}",
                defaults: new { controller = "Posts", action = "Edit", id = UrlParameter.Optional, title = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "ChiTietPost",
                url: "admin/chi-tiet-bai-viet/{title}-{id}",
                defaults: new { controller = "Posts", action = "Details", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "XoaPost",
                url: "admin/xoa-bai-viet-{id}",
                defaults: new { controller = "Posts", action = "Delete", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "QuanLyBlog",
                url: "Admin/quan-ly-blog",
                defaults: new { controller = "Blogs", action = "Index" }
            );

            routes.MapRoute(
               name: "XoaBlog",
               url: "Admin/xoa-blog/{id}",
               defaults: new { controller = "Blogs", action = "Delete", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "ChiTietBlog",
              url: "Admin/chi-tiet-blog/{title}-{id}",
              defaults: new { controller = "Blogs", action = "Details", id = UrlParameter.Optional, title = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "ChinhSuaBlog",
              url: "Admin/chinh-sua-blog/{title}-{id}",
              defaults: new { controller = "Blogs", action = "Edit", id = UrlParameter.Optional, title = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "ThemBlogMoi",
              url: "Admin/them-blog-moi",
              defaults: new { controller = "Blogs", action = "Create" }
          );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
