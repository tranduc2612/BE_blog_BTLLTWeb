using BE_blog_BTLLTWeb.Areas.Admin.Models;
using BE_blog_BTLLTWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BE_blog_BTLLTWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Route("Admin")]
	[AuthenticationAdmin]
    public class PostController : Controller
	{
		BlogBtlContext db = new BlogBtlContext();
		[Route("")]
        [Route("index")]
        public IActionResult Index()
		{
			List<Blog> lst = db.Blogs.OrderByDescending(x=>x.CreateAt).ToList();
			List<BlogTable> tableBlog = new List<BlogTable>();
			foreach(var blog in lst)
			{
				BlogTable tableData = new BlogTable(blog);
				tableBlog.Add(tableData);
            }
			return View(tableBlog);
		}
		[Route("")]
		[Route("Accept")]
		public IActionResult Accept(string idBlog)
		{
			Blog blog = db.Blogs.Where(x => x.IdBlog == int.Parse(idBlog)).SingleOrDefault();
			blog.Status = 2;
			db.SaveChanges();
			return RedirectToAction("Index", "Post", new { area = "Admin" });
		}

		[Route("Reject")]
		public IActionResult Reject(string idBlog)
		{
			Blog blog = db.Blogs.Where(x => x.IdBlog == int.Parse(idBlog)).SingleOrDefault();
			blog.Status = 3;
			db.SaveChanges();
			return RedirectToAction("Index", "Post", new { area = "Admin" });
		}
		[Route("")]
		[Route("Detail")]
		public IActionResult Detail(string idBlog) {
			Blog blog = db.Blogs.Where(x => x.IdBlog == int.Parse(idBlog)).FirstOrDefault();
			BlogTable data = new BlogTable(blog);
			return View(data);
		}

	}
}
