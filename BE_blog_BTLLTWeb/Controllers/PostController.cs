using BE_blog_BTLLTWeb.Models;
using BE_blog_BTLLTWeb.Models.Authentication;
using BE_blog_BTLLTWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace BE_blog_BTLLTWeb.Controllers
{
    public class PostController : Controller
    {
        private IHostingEnvironment _env;
        BlogBtlContext db = new BlogBtlContext();
        public PostController(ILogger<PostController> logger, IHostingEnvironment _environment)
        {
            _env = _environment;

        }
        [HttpGet]
        [Authentication]
        public IActionResult CreatePost()
        {
            List<Category> lst = db.Categories.ToList();
          
            return View(lst);
        }

        [Authentication]
        [HttpPost]
        public IActionResult CreatePost(string title,IFormFile image, string content,List<string> topic)
        {
            ViewBag.Content = "";
            ViewBag.Topic = "";
            ViewBag.Image = "";
			List<Category> lst = db.Categories.ToList();
			if (title== null)
            {
				ViewBag.TitlePost = "This field isn't empty !";
				return View(lst);
			}
            if(image == null)
            {
				ViewBag.ImagePost = "Please select your image !";
				return View(lst);
			}
            if(content== null)
            {
				ViewBag.ContentPost = "This field isn't empty !";
				return View(lst);
			}
			if (topic.Count == 0)
			{
				ViewBag.TopicPost = "Please select your topic post !";
				return View(lst);
			}


            Blog blog = new Blog();
            int currentId = (int)HttpContext.Session.GetInt32("idUser");
			blog.IdAccount = currentId;
            blog.Status = 1;
			blog.Title = title;
            blog.Content = content;
            blog.CreateAt = DateTime.Now;
            string filepath;
			if (image != null)
			{
				string fileUser = HttpContext.Session.GetString("UserName").ToString();
				string serverMapPath = Path.Combine(this._env.WebRootPath, "ImageTitle", fileUser);
				string serverMapPathFile = Path.Combine(serverMapPath, image.FileName);
				Directory.CreateDirectory(serverMapPath);
				using (var stream = new FileStream(serverMapPathFile, FileMode.Create))
				{
					image.CopyTo(stream);
				}
				filepath = "https://localhost:7237/" + "ImageTitle/" + fileUser + "/" + image.FileName;
                blog.ImageTitle = filepath;
			}

			foreach (var topicItem in topic)
            {
                var category = db.Categories.Find(int.Parse(topicItem));
                blog.IdCategories.Add(category);
			}
            db.Blogs.Add(blog);
            db.SaveChanges();
			List<Blog> currentUserBlog = db.Blogs.Where(x => x.IdAccount == currentId).ToList();
			return View("YourPost",currentUserBlog);

		}

        [HttpPost]
        public IActionResult UpLoadPostImage(List<IFormFile> files)
        {
            var filepath = "";  
            var userID = HttpContext.Session.GetString("UserName").ToString();
			var serverMapPath = Path.Combine(_env.WebRootPath, "ImagePost", userID);

            //Directory.GetCurrentDirectory()
            foreach (IFormFile photo in Request.Form.Files)
            {
                string milliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
                if (Directory.Exists(serverMapPath))
                {
                    string serverMapPathFile = Path.Combine(this._env.WebRootPath, "ImagePost", userID, milliseconds + photo.FileName);
                    using (var stream = new FileStream(serverMapPathFile, FileMode.Create))
                    {
                        photo.CopyTo(stream);
                    }
                }
                else
                {
                    Directory.CreateDirectory(serverMapPath);
                    string serverMapPathFile = Path.Combine(this._env.WebRootPath, "ImagePost", userID, milliseconds + photo.FileName);
                    using (var stream = new FileStream(serverMapPathFile, FileMode.Create))
                    {
                        photo.CopyTo(stream);
                    }
                }

                filepath = "https://localhost:7237/" + "ImagePost/" + userID + "/" + milliseconds + photo.FileName;
            }
            return Json(new { url = filepath });
        }


        public IActionResult DetailPost(int IdBlog)
		{
            string currentUser = HttpContext.Session.GetString("UserName");
            if(currentUser != null)
            {
			    string fullname = HttpContext.Session.GetString("FullName");
                TempData["iduser"] = HttpContext.Session.GetInt32("idUser");
				TempData["fullname"] = fullname;
                TempData["avatar"] = HttpContext.Session.GetString("Avatar");

			}

			Blog blog = db.Blogs.Where(x=>x.IdBlog == IdBlog).FirstOrDefault();
            DetailBlogViewModel detail = new DetailBlogViewModel(blog);
			return View(detail);
		}

        public IActionResult DeletePost(string idBlog, string idUser)
        {
            
            if(idBlog == null || idUser == null)
            {
				return RedirectToAction("YourPost");
			}
            int currentUser = (int)HttpContext.Session.GetInt32("idUser");
			if (currentUser == int.Parse(idUser))
            {
			    return RedirectToAction("YourPost");
			}

			return RedirectToAction("YourPost");
        }


		public IActionResult Category()
		{
			return View();
		}

        public JsonResult ListComment(string idPost)
        {
            try {
                string currentUser = HttpContext.Session.GetString("UserName");
				List<CommentViewModel> lst = new List<CommentViewModel>();
                List<CommentBlog> lstComment = db.CommentBlogs.Where(x => x.IdBlog == int.Parse(idPost)).ToList();
                foreach (CommentBlog comment in lstComment)
                {
                    CommentViewModel infoComment = new CommentViewModel(comment,currentUser);
                    lst.Add(infoComment);
				}
                return new JsonResult(new { lst });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { ex });
            }

		}

        [Authentication]
        public IActionResult YourPost()
        {
			int currentId = (int)HttpContext.Session.GetInt32("idUser");
			List<Blog> currentUserBlog = db.Blogs.Where(x=>x.IdAccount == currentId).OrderBy(x=>x.CreateAt).ToList();
            return View(currentUserBlog);
        }
	}
}
