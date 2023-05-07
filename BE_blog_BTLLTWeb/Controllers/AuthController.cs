using BE_blog_BTLLTWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace BE_blog_BTLLTWeb.Controllers
{
    public class AuthController : Controller
    {
        BlogBtlContext db = new BlogBtlContext();
		private static readonly Regex PassRegex = new Regex(@"^[a-zA-Z0-9!@#$%^&*]", RegexOptions.Compiled);
		private static readonly Regex EmailRegex = new Regex(@"^([\w-]+(\?\:\.[\w-]+)*)@((\?\:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(\?\:\.[a-z]{2})?)$", RegexOptions.Compiled);

		public IActionResult Login()
        {
			if (HttpContext.Session.GetString("UserName") == null)
			{
				return View();
			}
			return RedirectToAction("Index","Site");
        }

        [HttpPost]        
		public IActionResult Login(Account account)
		{
			if(account.UserName == "Admin")
			{
				AdminBlog admin = db.AdminBlogs.Where(x => account.Pass == x.AdminPass).FirstOrDefault();
				if(admin != null)
				{
					HttpContext.Session.SetString("Admin", admin.IdAdmin.ToString());
					return RedirectToAction("Index", "Post", new { area = "Admin" });
				}
				else
				{
					ViewBag.isExist = false;
					return View();
				}
			}

			Account acc = db.Accounts.Where(x => x.UserName == account.UserName && x.Pass == account.Pass).FirstOrDefault();
			if (acc != null)
			{
				if(acc.IdAdmin != null)
				{
					ViewBag.isBan = false;
					return View();
				}
                HttpContext.Session.SetString("UserName", acc.UserName.ToString());
				HttpContext.Session.SetString("FullName", acc.Fullname.ToString());
                HttpContext.Session.SetInt32("idUser", acc.IdAccount);
				if (acc.Avatar != null)
				{
					HttpContext.Session.SetString("Avatar", acc.Avatar.ToString());
				}

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
			ViewBag.isExist = false;
			if (HttpContext.Session.GetString("UserName") == null)
			{
				return View();
			}
			return RedirectToAction("Index", "Site");
		}

        [HttpPost]
		public IActionResult Register(string account,string email,string password, string passwordCheck,string fullname)
		{
			bool isPass = PassRegex.IsMatch(password);
			bool isEmail = EmailRegex.IsMatch(email);
			if (password == "" || password != passwordCheck || account == "" || !isPass || !isEmail)
			{
				return View();
			}
			Account acc = db.Accounts.Where(x => x.UserName == account || x.Email == email).FirstOrDefault();
			if(acc != null) { 
				ViewBag.isExist = true;
                return View();
            }
            else
			{
				Account newAccount = new Account();
				newAccount.UserName = account;
				newAccount.Pass = password;
				newAccount.Email = email;
				newAccount.Fullname = fullname;
				newAccount.Avatar = "./../images/icons/social/iconmonstr-user-circle-thin.svg";
				db.Accounts.Add(newAccount);
				db.SaveChanges();
				return RedirectToAction("Login", "Auth");
            }

        }

		public IActionResult LogOut()
		{
			HttpContext.Session.Clear();
			

			return RedirectToAction("Index","Site");
		}
	}
}
