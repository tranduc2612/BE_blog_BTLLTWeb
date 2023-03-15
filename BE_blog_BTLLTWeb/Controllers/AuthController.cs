using Microsoft.AspNetCore.Mvc;

namespace BE_blog_BTLLTWeb.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Logout()
        {
            return View();
        }
    }
}
