namespace BE_blog_BTLLTWeb.Models
{
	public class CategoryBlog
	{
		private int idBlog;
		private string author;
		private string title;
		private string createAt;
		private string content;
		private string image;
		List<Category> category;
		public CategoryBlog(int idBlog, string author, string title,string image, string createAt, string content, List<Category> category)
		{
			this.idBlog = idBlog;
			this.author = author;
			this.title = title;
			this.createAt = createAt;
			this.content = content;
			this.category = category;
			this.image = image;
		}

		public int IdBlog { get => idBlog; set => idBlog = value; }
		public string Author { get => author; set => author = value; }
		public string Title { get => title; set => title = value; }
		public string CreateAt { get => createAt; set => createAt = value; }
		public string Content { get => content; set => content = value; }
		public List<Category> Category { get => category; set => category = value; }
		public string Image { get => image; set => image = value; }
	}
}
