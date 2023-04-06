using BE_blog_BTLLTWeb.Models;

namespace BE_blog_BTLLTWeb.Areas.Admin.Models
{
    public class BlogTable
    {
        private Blog _blog;
        private List<Category> _category;
        private string _nameAuthor;
        BlogBtlContext db = new BlogBtlContext();
        public BlogTable(Blog blog)
        {
            _blog= blog;
            _nameAuthor = db.Accounts.Where(x => x.IdAccount == blog.IdAccount).FirstOrDefault().Fullname;
			_category = db.Blogs.Where(x=>x.IdBlog==blog.IdBlog).SelectMany(x=>x.IdCategories).ToList();    
        }

        public Blog Blog { get => _blog; set => _blog = value; }
        public List<Category> Category { get => _category; set => _category = value; }
		public string NameAuthor { get => _nameAuthor; set => _nameAuthor = value; }
	}
}
