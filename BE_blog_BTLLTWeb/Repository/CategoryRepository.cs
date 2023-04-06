using BE_blog_BTLLTWeb.Models;

namespace BE_blog_BTLLTWeb.Repository
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly BlogBtlContext _context;
		public CategoryRepository(BlogBtlContext context) {
			_context = context;
		}
		public Category Add(Category category)
		{
			_context.Categories.Add(category);
			_context.SaveChanges();
			return category;
		}

		public Category Delete(Category category)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Category> GetAll()
		{
			return _context.Categories;
		}

		public Category GetDetailCategory(string idCategory)
		{
			return _context.Categories.Find(idCategory);
		}

		public Category Update(string idCategory)
		{
			throw new NotImplementedException();
		}
	}
}
