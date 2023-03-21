using Microsoft.AspNetCore.Mvc;
using System.IO;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace BE_blog_BTLLTWeb.Controllers
{
    public class PostController : Controller
    {
        private IHostingEnvironment _env;
        
        public PostController(ILogger<PostController> logger, IHostingEnvironment _environment)
        {
            _env = _environment;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(string name)
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpLoadPostImage(List<IFormFile> files)
        {
            var filepath = "";  
            var userID = "iduser1";
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
