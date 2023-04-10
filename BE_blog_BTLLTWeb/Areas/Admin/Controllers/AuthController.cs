using BE_blog_BTLLTWeb.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BE_blog_BTLLTWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    [AuthenticationAdmin]
    public class AuthController : Controller
    {
        [Route("")]
        [Route("LogOut")]
        public IActionResult LogOut()
        {
            HttpContext.Session.SetString("Admin", "");
            return RedirectToAction("Login","Auth");
        }
    }
}
