using BE_blog_BTLLTWeb.Areas.Admin.Models;
using BE_blog_BTLLTWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BE_blog_BTLLTWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    [AuthenticationAdmin]
    public class UserController : Controller
    {
        BlogBtlContext db = new BlogBtlContext();
        [Route("")]
        [Route("User")]
        public IActionResult UserList()
        {
            List<Account> lst = db.Accounts.ToList();
            return View(lst);
        }

		[Route("Ban")]
		public IActionResult Ban(string idUser,string idAdmin)
		{
			List<Account> lst = db.Accounts.ToList();
            if(idUser == null || idAdmin == null)
            {
                return View(lst);
            }
            lst.Where(x => x.IdAccount == int.Parse(idUser)).FirstOrDefault().IdAdmin = int.Parse(idAdmin);
            db.SaveChanges();
			return RedirectToAction("UserList", "User", new { area = "Admin" });
		}

		[Route("UnBan")]
		public IActionResult UnBan(string id)
		{
			List<Account> lst = db.Accounts.ToList();
			if (id == null || id == null)
			{
				return View(lst);
			}
			lst.Where(x => x.IdAccount == int.Parse(id)).FirstOrDefault().IdAdmin = null;
			db.SaveChanges();
			return RedirectToAction("UserList", "User", new { area = "Admin" });
		}

	}
}
