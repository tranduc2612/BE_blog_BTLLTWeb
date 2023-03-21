using BE_blog_BTLLTWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BE_blog_BTLLTWeb.Controllers
{
    public class SiteController : Controller
    {
        BlogBtlContext db = new BlogBtlContext();
        public IActionResult Index()
        {
            var lst = db.Accounts.ToList();
            return View(lst);
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
