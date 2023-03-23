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
                HttpContext.Session.SetString("UserName", acc.UserName.ToString());
                HttpContext.Session.SetString("idUser", acc.IdAccount.ToString());
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
			if(passord != passwordCheck || account == "")
			{
				return View();
			}
			Account acc = db.Accounts.Where(x => x.UserName == account && x.Pass == passord).FirstOrDefault();
			if(acc != null) { 
				// tai khoan da ton tai
                return View();
            }
            else
			{
				Account newAccount = new Account();
				newAccount.UserName = account;
				newAccount.Pass = passord;
				//newAccount.
				//db.Accounts.Add(acc);
                return RedirectToAction("Index", "Site");
            }

        }
	}
}
