using BE_blog_BTLLTWeb.Areas.Admin.Models;
using BE_blog_BTLLTWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace BE_blog_BTLLTWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin")]
	[AuthenticationAdmin]
	public class TopicController : Controller
	{
		private IHostingEnvironment _env;

		public TopicController(IHostingEnvironment _environment) { 
            _env = _environment;
		}

		BlogBtlContext db = new BlogBtlContext();
		[Route("")]
		[Route("ListTopic")]
		public IActionResult ListTopic()
		{
			List<Category> categories = db.Categories.ToList();
			return View(categories);
		}

		public HttpContext GetHttpContext()
		{
			return HttpContext;
		}

		[Route("")]
		[Route("Add")]
		[HttpPost]
		public IActionResult Add(string namecategory,IFormFile image)
		{
			if(namecategory == null || image == null) {
				return RedirectToAction("ListTopic", "Topic", new { area = "Admin" });
			}

			Category newCate = new Category();
			newCate.NameCategory = namecategory;
			string serverMapPathFile = Path.Combine(this._env.WebRootPath, "ImageTopic", image.FileName);
			using (var stream = new FileStream(serverMapPathFile, FileMode.Create))
			{
				image.CopyTo(stream);
			}
			string filepath =  "../ImageTopic/" + image.FileName;
			newCate.Img = filepath;
			string AdminId = HttpContext.Session.GetString("Admin");
			newCate.IdAdmin = int.Parse(AdminId);
			db.Categories.Add(newCate);
			db.SaveChanges();
			return RedirectToAction("ListTopic", "Topic", new { area = "Admin" });
		}

		[Route("")]
		[Route("Update")]
		public ActionResult Update(string id)
		{
			Category Category = db.Categories.Where(x=>x.IdCategory==int.Parse(id)).FirstOrDefault();
			return View(Category);
		}

        [Route("")]
        [Route("Update")]
		[HttpPost]
        public ActionResult Update(string id,string newname,IFormFile image)
        {
			if (id == null)
			{
                return RedirectToAction("ListTopic", "Topic", new { area = "Admin" });
            }
            Category cate = db.Categories.Where(x=>x.IdCategory == int.Parse(id)).FirstOrDefault();
			if (cate == null)
			{
                return RedirectToAction("ListTopic", "Topic", new { area = "Admin" });
            }
			if(newname != null)
			{
				cate.NameCategory = newname;
			}

			if(image != null)
			{
                string serverMapPathFile = Path.Combine(this._env.WebRootPath, "ImageTopic", image.FileName);
                using (var stream = new FileStream(serverMapPathFile, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                string filepath = "../ImageTopic/" + image.FileName;
                cate.Img = filepath;
            }


            string AdminId = HttpContext.Session.GetString("Admin");
            cate.IdAdmin = int.Parse(AdminId);
			db.SaveChanges();
			TempData["Message"] = "Update Success !";
			return RedirectToAction("ListTopic", "Topic", new { area = "Admin" });
        }

        [Route("")]
        [Route("Delete")]
        public ActionResult Delete(string id)
        {
           if(id == null) return RedirectToAction("ListTopic", "Topic", new { area = "Admin" });

			Category category = db.Categories.Find(int.Parse(id));
			if (category == null)
			{
				return RedirectToAction("ListTopic", "Topic", new { area = "Admin" });
			}
            var Blogs = db.Categories.Where(x=>x.IdCategory == int.Parse(id)).SelectMany(x=>x.IdBlogs).ToList();
			foreach(var blog in Blogs)
			{
                var blog1 = db.Blogs.Include(c => c.IdCategories).FirstOrDefault(c => c.IdBlog == blog.IdBlog);
                var cateToRemove = blog1.IdCategories.FirstOrDefault(b => b.IdCategory == int.Parse(id));

                if (cateToRemove != null)
                {
                    blog1.IdCategories.Remove(cateToRemove);
                    db.SaveChanges();
                }
            }

			db.Categories.Remove(category);
			db.SaveChanges();
			TempData["Message"] = "Delete Success !";
            return RedirectToAction("ListTopic", "Topic", new { area = "Admin" });
        }

    }
}
