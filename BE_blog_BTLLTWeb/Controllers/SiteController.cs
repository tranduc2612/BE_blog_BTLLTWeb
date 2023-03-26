using BE_blog_BTLLTWeb.Models;
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
