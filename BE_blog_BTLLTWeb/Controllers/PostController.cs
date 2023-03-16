using Microsoft.AspNetCore.Mvc;

namespace BE_blog_BTLLTWeb.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreatePost()
        {
            return View();
        }

		public IActionResult DetailPost()
		{
			return View();
		}

		public IActionResult Category()
		{
			return View();
		}

        public IActionResult YourPost()
        {
            return View();
        }
	}
}
