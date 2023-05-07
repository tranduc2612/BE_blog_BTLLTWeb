using Azure;
using BE_blog_BTLLTWeb.Models;
using BE_blog_BTLLTWeb.Models.Authentication;
using BE_blog_BTLLTWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Reflection.Metadata;
using System.Security;
using X.PagedList;
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
            blog.AmountLike = 0;
            string filepath;
			if (image != null)
			{
				string fileUser = HttpContext.Session.GetString("UserName").ToString();
				string serverMapPath = Path.Combine(this._env.WebRootPath, "ImageTitle", fileUser);
                if (!Directory.Exists(serverMapPath))
                {
					Directory.CreateDirectory(serverMapPath);
				}

				string serverMapPathFile = Path.Combine(serverMapPath, image.FileName);
			
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
			List<Blog> currentUserBlog = db.Blogs.Where(x => x.IdAccount == currentId).OrderByDescending(x => x.CreateAt).ToList();
			PagedList<Blog> lstTypeXList = new PagedList<Blog>(currentUserBlog, 1, 5);
			return View("YourPost", lstTypeXList);
            
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
		
        
        [Authentication]
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
                db.Blogs.Find(int.Parse(idPost)).AmountLike -= 1;
                db.LikeBlogs.Remove(isLiked);
			}
			else
            {
                LikeBlog like = new LikeBlog();
                like.LikeAt = DateTime.Now;
                like.IdAccount= int.Parse(idUser);
                like.IdBlog = int.Parse(idPost);
                db.LikeBlogs.Add(like);
				db.Blogs.Find(int.Parse(idPost)).AmountLike += 1;
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
            if(blog == null)
            {
                return RedirectToAction("Index", "Site");
            }
            DetailBlogViewModel detail = new DetailBlogViewModel(blog);
            BlogByTypeViewModel relative = new BlogByTypeViewModel(db.Blogs.ToList(), detail.IdCategory);
			List<CategoryBlog> listBeginRelative = relative.ListBlogByType;
            List<CategoryBlog> realRelative = new List<CategoryBlog>();
            foreach(var item in listBeginRelative)
            {
                if(item.IdBlog != IdBlog)
                {
                    realRelative.Add(item);
				}
            }

            ViewBag.relativeBlog = realRelative;
			return View(detail);
		}

        [Authentication]
        public IActionResult DeletePost(string idBlog, string idUser)
        {
          
			if (idBlog == null || idUser == null || int.Parse(idUser) != (int)HttpContext.Session.GetInt32("idUser"))
            {

				return RedirectToAction("YourPost", "Post");
			}

			Blog blog = db.Blogs.FirstOrDefault(a => a.IdBlog == int.Parse(idBlog));

			if (blog == null)
            {

				return RedirectToAction("YourPost", "Post");
			}

			List<LikeBlog> listlikeblog = db.LikeBlogs.Where(x => x.IdBlog == int.Parse(idBlog)).ToList();
            List<CommentBlog> listcommentblog = db.CommentBlogs.Where(x => x.IdBlog == int.Parse(idBlog)).ToList();

            if(listlikeblog != null)
            {
                db.LikeBlogs.RemoveRange(listlikeblog);
            }
            if(listcommentblog != null)
            {
                db.CommentBlogs.RemoveRange(listcommentblog);
            }

            db.Categories.ToList();

            var listCategoryotrongBlog = db.Blogs.Where(x => x.IdBlog == int.Parse(idBlog)).SelectMany(x => x.IdCategories).ToList();

            foreach (var item in listCategoryotrongBlog)
            {
                var category = db.Categories.Include(c => c.IdBlogs).FirstOrDefault(c => c.IdCategory == item.IdCategory);
                var blogToRemove = category.IdBlogs.FirstOrDefault(b => b.IdBlog == int.Parse(idBlog));

                if (blogToRemove != null)
                {
                    category.IdBlogs.Remove(blogToRemove);
                    db.SaveChanges();
                }
            }
            db.Blogs.Remove(blog);
			db.SaveChanges();
			
			return RedirectToAction("YourPost","Post");
        }


		public IActionResult Category(string? type,int? page)
		{
			int pageNum = page == null || page < 1 ? 1 : page.Value;
			int pageSize = 9;
			if (type != null)
            {
				TempData["namecategory"] = db.Categories.Find(int.Parse(type)).NameCategory;
				BlogByTypeViewModel bloglistType = new BlogByTypeViewModel(type);
                List<CategoryBlog> lstType = bloglistType.ListBlogByType;
                PagedList<CategoryBlog> lstTypeXList = new PagedList<CategoryBlog>(lstType,pageNum,pageSize);
				return View(lstTypeXList);
            }

			TempData["namecategory"] = "All";
			BlogByTypeViewModel blogModel = new BlogByTypeViewModel();
			List<CategoryBlog> allList = blogModel.ListBlogByType;
			PagedList<CategoryBlog> lstAllXList = new PagedList<CategoryBlog>(allList, pageNum, pageSize);
			return View(lstAllXList);
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
        [Authentication]
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
        public IActionResult YourPost(int? page, string? date, string? name)
        {
			int pageNum = page == null || page < 1 ? 1 : page.Value;
			int pageSize = 5;
			if (HttpContext.Session.GetInt32("idUser") != null && date == null && name == null)
            {
				int currentId = (int)HttpContext.Session.GetInt32("idUser");
				List<Blog> currentUserBlog = db.Blogs.Where(x => x.IdAccount == currentId).OrderByDescending(x => x.CreateAt).ToList();
				PagedList<Blog> lstTypeXList = new PagedList<Blog>(currentUserBlog, pageNum, pageSize);
				return View(lstTypeXList);
            }
            else
            {
                List<Blog> lst = db.Blogs.ToList();
                if (date != null)
                {
                    var newDate = date.Trim().Split("to");
                    DateTime beginDate = DateTime.Parse(newDate[0]);
                    DateTime endDate = DateTime.Parse(newDate[1]);
                    lst = lst.Where(x => x.CreateAt > beginDate && x.CreateAt <= endDate).ToList();
                }
                if(name != null)
                {
                    lst = lst.Where(x => x.Title.Contains(name)).ToList();
                }
                PagedList<Blog> lstTypeXList = new PagedList<Blog>(lst, pageNum, pageSize);
                ViewBag.name = name;
                ViewBag.date = date;
                return View(lstTypeXList);
            }

        }

		
	}
}
