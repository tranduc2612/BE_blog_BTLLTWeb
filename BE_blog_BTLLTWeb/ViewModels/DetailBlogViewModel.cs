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
		private int idAccount;
		private string amountLike;
		private string createTime;
		private List<string> nameCategory;

		public DetailBlogViewModel(Blog blog)
		{
			Blog = blog;
			
			title = blog.Title;
			image = blog.ImageTitle;
			content = blog.Content;
			status = (int)blog.Status;
			idAccount = (int)blog.IdAccount;
			createTime = blog.CreateAt.Date.ToString("MMM dd, yyyy");
			author = db.Accounts.Find(idAccount).Fullname;
			nameCategory = new List<string>();
			var lstCategory = db.Blogs.Where(x => x.IdBlog == blog.IdBlog).SelectMany(x => x.IdCategories).ToList();
			foreach (var category in lstCategory)
			{
				nameCategory.Add(category.NameCategory);
			}

		}
		public Blog Blog { get; set; }
		public string Author { get => author; set => author = value; }
		public string Title { get => title; set => title = value; }
		public string Image { get => image; set => image = value; }
		public string Content { get => content; set => content = value; }
		public int Status { get => status; set => status = value; }
		public int IdAccount { get => idAccount; set => idAccount = value; }
		public string AmountLike { get => amountLike; set => amountLike = value; }
		public string CreateTime { get => createTime; set => createTime = value; }
		public List<string> NameCategory { get => nameCategory; set => nameCategory = value; }
	}
}
