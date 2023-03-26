using BE_blog_BTLLTWeb.Models;
using BE_blog_BTLLTWeb.Models.Authentication;
using BE_blog_BTLLTWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.IO;
using Xunit.Abstractions;
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

        public JsonResult LikePost(string idPost,string idUser)
        {
            if(idPost == null || idUser == null)
            {
                string err = "err like";
				return new JsonResult(new { err });
			}

            LikeBlog isLiked = db.LikeBlogs.Where(x=>x.IdAccount== int.Parse(idUser) && x.IdBlog == int.Parse(idPost)).FirstOrDefault();
            if(isLiked != null)
            {
                db.LikeBlogs.Remove(isLiked);
			}
			else
            {
                LikeBlog like = new LikeBlog();
                like.LikeAt = DateTime.Now;
                like.IdAccount= int.Parse(idUser);
                like.IdBlog = int.Parse(idPost);
                db.LikeBlogs.Add(like);
			}
			db.SaveChanges();
			int mountLike = db.LikeBlogs.Where(x => x.IdBlog == int.Parse(idPost)).Count();
			return new JsonResult(new { isLiked, mountLike });




		}


		public IActionResult DetailPost(int IdBlog)
		{
			string currentUser = HttpContext.Session.GetString("UserName");
            if(currentUser != null)
            {
			    string fullname = HttpContext.Session.GetString("FullName");
                TempData["idcurrentuser"] = HttpContext.Session.GetInt32("idUser");
				TempData["fullname"] = fullname;
                TempData["avatar"] = HttpContext.Session.GetString("Avatar");
                if (db.LikeBlogs.Where(x => x.IdAccount == HttpContext.Session.GetInt32("idUser") && x.IdBlog == IdBlog).FirstOrDefault() != null)
                {
                    TempData["like"] = "active";
                }
                else
                {
                    TempData["like"] = "";

				}
			}
            TempData["mountlike"] = db.LikeBlogs.Where(x => x.IdBlog == IdBlog).Count();
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


		public IActionResult Category(string? type)
		{   
            if(type != null)
            {
                BlogByTypeViewModel bloglistType = new BlogByTypeViewModel(type);
                List<CategoryBlog> lstType = bloglistType.ListBlogByType;
                return View(lstType);
            }

			BlogByTypeViewModel blogModel = new BlogByTypeViewModel();
			List<CategoryBlog> allList = blogModel.ListBlogByType;
			return View(allList);
		}

	    

        public JsonResult ListComment(int idBlog)
        {
            try {
                string id = idBlog.ToString();
                var lst = RenderListComment(id);

				return new JsonResult(new { lst });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { ex });
            }
		}

        public List<CommentViewModel> RenderListComment(string idPost)
        {
			string currentUser = HttpContext.Session.GetString("UserName");
			List<CommentViewModel> lst = new List<CommentViewModel>();
			List<CommentBlog> lstComment = db.CommentBlogs.Where(x => x.IdBlog == int.Parse(idPost)).OrderByDescending(x=>x.CreateAt).ToList();
			foreach (CommentBlog comment in lstComment)
			{
				CommentViewModel infoComment = new CommentViewModel(comment, currentUser);
				lst.Add(infoComment);
			}
            return lst;
		}

        [HttpPost]
        public JsonResult PostComment(string idPost, string idAcc, string cMessage)
        {
            if(cMessage == null || idPost == null || idAcc == null)
            {
                string err = "";
                return new JsonResult(new { err });
			}
            CommentBlog comment = new CommentBlog();
            comment.Content = cMessage;
            comment.IdBlog = int.Parse(idPost);
            comment.IdAccount = int.Parse(idAcc);
            comment.CreateAt = DateTime.Now;
            db.CommentBlogs.Add(comment);
            db.SaveChanges();

            var lst = RenderListComment(idPost);

            return new JsonResult(new { lst });
        }

        [HttpDelete]
        public JsonResult DeleteComment(string id,string idPost)
        {
            if(id == "-1")
            {
                string err = "err idcomment";
				return new JsonResult(new { err });
			}
			CommentBlog comment = db.CommentBlogs.Find(int.Parse(id));
            if (comment != null)
            {
				db.CommentBlogs.Remove(comment);
				db.SaveChanges();
			}
			var lst = RenderListComment(idPost);
			return new JsonResult(new { lst });
		}

		[Authentication]
        public IActionResult YourPost()
        {
            if (HttpContext.Session.GetInt32("idUser") != null)
            {
				int currentId = (int)HttpContext.Session.GetInt32("idUser");
				List<Blog> currentUserBlog = db.Blogs.Where(x => x.IdAccount == currentId).OrderByDescending(x => x.CreateAt).ToList();
                 return View(currentUserBlog);
			}
            return View();
        }
	}
}
