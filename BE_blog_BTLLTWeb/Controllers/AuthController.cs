using BE_blog_BTLLTWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BE_blog_BTLLTWeb.Controllers
{
    public class AuthController : Controller
    {
        BlogBtlContext db = new BlogBtlContext();
		public IActionResult Login()
        {
            return View();
        }
        [HttpPost]        
        
		public IActionResult Login(Account account)
		{
            if(ModelState.IsValid)
            {
                Account acc = db.Accounts.Where(x=>x.UserName==account.UserName && x.Pass == account.Pass).FirstOrDefault();
                if(acc != null)
                {
                    return RedirectToAction("Home", "Site");
                }
                else
                {
					ViewBag.isErr = true;
					return View();
                }
            }
            return View();
		}

		public IActionResult Register()
        {
            return View();
        }
    }
}
