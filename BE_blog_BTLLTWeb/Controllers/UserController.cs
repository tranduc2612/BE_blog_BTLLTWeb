using BE_blog_BTLLTWeb.Models;
using BE_blog_BTLLTWeb.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BE_blog_BTLLTWeb.Controllers
{
	public class UserController : Controller
	{
		BlogBtlContext db = new BlogBtlContext();
		[Authentication]
		public IActionResult Profile()
		{
			string account = HttpContext.Session.GetString("UserName");
			Account currentUser = db.Accounts.Where(x => x.UserName == account).FirstOrDefault();
			return View(currentUser);
		}

		
	}
}
