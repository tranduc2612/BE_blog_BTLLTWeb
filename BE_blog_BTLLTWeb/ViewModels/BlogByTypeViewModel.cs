using BE_blog_BTLLTWeb.Models;

namespace BE_blog_BTLLTWeb.ViewModels
{
	public class BlogByTypeViewModel
	{
		BlogBtlContext db = new BlogBtlContext();

		List<CategoryBlog> listBlogByType = new List<CategoryBlog>();

		public List<CategoryBlog> ListBlogByType { get => listBlogByType; set => listBlogByType = value; }

		public BlogByTypeViewModel(string? type)
		{
			var blogs = db.Categories.Where(x => x.IdCategory == int.Parse(type)).SelectMany(x => x.IdBlogs).ToList();
			if(blogs.Count != 0)
			{
				foreach(var item in blogs)
			{
				int idBlog = item.IdBlog;
				string title = item.Title;
				string content = item.Content;
				string createAt = item.CreateAt.ToString("MMM dd, yyyy");
				string author = db.Accounts.Find(item.IdAccount).Fullname;
				string img = item.ImageTitle;

				List<Category> category = new List<Category>();
				var CategoryBlog = db.Blogs.Where(x => x.IdBlog == item.IdBlog).SelectMany(x => x.IdCategories).ToList();

				foreach (var cateinblog in CategoryBlog)
				{
					category.Add(db.Categories.Find(cateinblog.IdCategory));
				}

				CategoryBlog data = new CategoryBlog(idBlog, author, title, img, createAt, content, category);
				listBlogByType.Add(data);
			}
			}
		}

		public BlogByTypeViewModel()
		{
			var lst = db.Blogs.ToList();

			foreach(var item in lst)
			{

				int idBlog = item.IdBlog;
				string title = item.Title;
				string content = item.Content;
				string createAt = item.CreateAt.ToString("MMM dd, yyyy");
				string author = db.Accounts.Find(item.IdAccount).Fullname;
				string img = item.ImageTitle;
				var CategoryBlog = db.Blogs.Where(x => x.IdBlog == item.IdBlog).SelectMany(x => x.IdCategories).ToList();
				List<Category> category = new List<Category>();
				
				foreach (var cateinblog in CategoryBlog)
				{
					category.Add(db.Categories.Find(cateinblog.IdCategory));
				}

				CategoryBlog data = new CategoryBlog(idBlog, author, title, img, createAt, content , category);
				listBlogByType.Add(data);
			}
		}
	}
}
