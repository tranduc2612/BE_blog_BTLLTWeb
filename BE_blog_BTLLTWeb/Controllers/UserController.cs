﻿using Microsoft.AspNetCore.Mvc;

namespace BE_blog_BTLLTWeb.Controllers
{
	public class UserController : Controller
	{

		public IActionResult Profile()
		{
			return View();
		}
	}
}