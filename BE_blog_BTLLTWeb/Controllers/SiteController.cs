using BE_blog_BTLLTWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BE_blog_BTLLTWeb.Controllers
{
    public class SiteController : Controller
    {
        public IActionResult Index()
        {

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
