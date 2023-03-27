using BE_blog_BTLLTWeb.Models;
using BE_blog_BTLLTWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BE_blog_BTLLTWeb.Controllers
{
    public class SiteController : Controller
    {
        BlogBtlContext db = new BlogBtlContext();
        public IActionResult Index()
        {
            //HttpContext.Session.SetString("UserName", "tranminhduc");
            //HttpContext.Session.SetInt32("idUser", 1);
            //HttpContext.Session.SetString("FullName", "Trần Minh Đức");
            //HttpContext.Session.SetString("Avatar", "./../images/avatars/user-01.jpg");
            List<Blog> blogTop5 = db.Blogs.OrderByDescending(x=>x.AmountLike).Take(5).ToList();
            List<DetailBlogViewModel> lstBlog = new List<DetailBlogViewModel>();

			foreach (var item in blogTop5)
            {
                DetailBlogViewModel blog = new DetailBlogViewModel(item);
				lstBlog.Add(blog);
			}
         
            List<Category> lstCategory = db.Categories.OrderByDescending(x=>x.NameCategory).ToList();
			ViewBag.listpopular = lstBlog;
            ViewBag.listcategory = lstCategory;
			return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult FindAdvance()
        {
            return View();
        }
    }
}
