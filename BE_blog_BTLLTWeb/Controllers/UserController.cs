using BE_blog_BTLLTWeb.Models;
using BE_blog_BTLLTWeb.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.RegularExpressions;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace BE_blog_BTLLTWeb.Controllers
{
	public class UserController : Controller
	{
		private IHostingEnvironment _env;
		BlogBtlContext db = new BlogBtlContext();
		private static readonly Regex PassRegex = new Regex(@"^[a-zA-Z0-9!@#$%^&*]", RegexOptions.Compiled);
		private static readonly Regex EmailRegex = new Regex(@"^([\w-]+(\?\:\.[\w-]+)*)@((\?\:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(\?\:\.[a-z]{2})?)$", RegexOptions.Compiled);
		private static readonly Regex PhoneRegex = new Regex(@"^[0-9]", RegexOptions.Compiled);

		public UserController(IHostingEnvironment _environment)
		{
			_env = _environment;
		}
		[Authentication]
		public IActionResult Profile()
		{
			string account = HttpContext.Session.GetString("UserName");
			var data = ViewData["email"];
			Account currentUser = db.Accounts.Where(x => x.UserName == account).FirstOrDefault();
			return View(currentUser);
		}

		[HttpPost]
		public IActionResult Profile(string fullName, string email,string address,string phone,string password,string passwordConfirm, IFormFile file)
		{
			Account currentUser = db.Accounts.Where(x => x.UserName == HttpContext.Session.GetString("UserName")).FirstOrDefault();
			int temp = 0;
			if (fullName == null)
			{
				ViewData["fullname"] = "Please enter your full name";
				temp++;
			}
			if(email == null)
			{
				ViewData["email"] = "Please enter your email";
				temp++;
			}
			if(address == null)
			{
				ViewData["address"] = "Please enter your address";
				temp++;
			}
			if(phone == null)
			{
				ViewData["phone"] = "Please enter your phone";
				temp++;

			}
			if (password == null)
			{
				ViewData["password"] = "Please enter your password";
				temp++;

			}

			if (temp != 0)
			{
				return View(currentUser);
			}

			if (!EmailRegex.IsMatch(email))
			{
				ViewData["email"] = "Your email isn't correct format !";
				return View(currentUser);
			}
			if (!PhoneRegex.IsMatch(phone))
			{
				ViewData["phone"] = "Your phone isn't correct format !";
				return View(currentUser);
			}
			if (!PassRegex.IsMatch(password))
			{
				ViewData["password"] = "Your password isn't correct format !";
				return View(currentUser);
			}
			if (password != passwordConfirm)
			{
				ViewData["password"] = "Your password isn't match with confirm password !";
				return View(currentUser);
			}
			currentUser.Fullname = fullName;
			currentUser.Email = email;
			currentUser.Address = address;
			currentUser.PhoneNumber = phone;
			currentUser.Pass= password;

			if(file != null)
			{
				string fileUser = HttpContext.Session.GetString("UserName").ToString();
				string serverMapPath = Path.Combine(this._env.WebRootPath, "images", "avatars", fileUser);
				string serverMapPathFile = Path.Combine(serverMapPath, file.FileName);
				Directory.CreateDirectory(serverMapPath);
				using (var stream = new FileStream(serverMapPathFile, FileMode.Create))
				{
					file.CopyTo(stream);
				}
				string filepath = "https://localhost:7237/" + "images/avatars/" + fileUser + "/"  + file.FileName;
				currentUser.Avatar = filepath;
				HttpContext.Session.SetString("Avatar", filepath);
			}

			ViewData["Sussess"] = "Update Success !";
			db.SaveChanges();	
			return View(currentUser);


		}



	}
}
