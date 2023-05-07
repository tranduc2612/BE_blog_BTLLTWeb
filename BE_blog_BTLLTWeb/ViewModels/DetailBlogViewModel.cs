using BE_blog_BTLLTWeb.Models;

namespace BE_blog_BTLLTWeb.ViewModels
{
	public class DetailBlogViewModel
	{
		BlogBtlContext db = new BlogBtlContext();
		private string author;
		private string title;
		private string image;
		private string content;
		private int status;
		private int idAuthor;
		private int amountLike;
		private string createTime;
		private string idBlog;
		private List<string> nameCategory;
		private List<string> idCategory;

		public DetailBlogViewModel(Blog blog)
		{
			Blog = blog;
			IdBlog = blog.IdBlog.ToString();	
			title = blog.Title;
			image = blog.ImageTitle;
			content = blog.Content;
			status = (int)blog.Status;
			idAuthor = (int)blog.IdAccount;
			createTime = blog.CreateAt.Date.ToString("MMM dd, yyyy");
			author = db.Accounts.Find(idAuthor).Fullname;
			nameCategory = new List<string>();
			idCategory = new List<string>();
			var lstCategory = db.Blogs.Where(x => x.IdBlog == blog.IdBlog).SelectMany(x => x.IdCategories).ToList();
			foreach (var category in lstCategory)
			{
				string catestring = category.IdCategory.ToString();
				idCategory.Add(catestring);
				nameCategory.Add(category.NameCategory);
			}

		}
		public Blog Blog { get; set; }
		public string Author { get => author; set => author = value; }
		public string Title { get => title; set => title = value; }
		public string Image { get => image; set => image = value; }
		public string Content { get => content; set => content = value; }
		public int Status { get => status; set => status = value; }
		public int IdAccount { get => idAuthor; set => idAuthor = value; }
		public int AmountLike { get => amountLike; set => amountLike = value; }
		public string CreateTime { get => createTime; set => createTime = value; }
		public List<string> NameCategory { get => nameCategory; set => nameCategory = value; }
		public string IdBlog { get => idBlog; set => idBlog = value; }
		public List<string> IdCategory { get => idCategory; set => idCategory = value; }
	}
}
