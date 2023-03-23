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
			Account acc = db.Accounts.Where(x => x.UserName == account.UserName && x.Pass == account.Pass).FirstOrDefault();
			if (acc != null)
			{
				return RedirectToAction("Index", "Site");
			}
			else
			{
				ViewBag.isExist = false;
				return View();
			}			
		}

		public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
		public IActionResult Register(string account,string email,string passord,string passwordCheck)
		{
			if(passord != passwordCheck)
			{
				return View();
			}

			Account acc = (Account)from x in db.Accounts where x.UserName == account && x.Pass == passord select x;

			return View();
		}
	}
}
