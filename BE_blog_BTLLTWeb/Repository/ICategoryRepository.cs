using BE_blog_BTLLTWeb.Models;

namespace BE_blog_BTLLTWeb.Repository
{
	public interface ICategoryRepository
	{
		Category Add(Category category);
		Category Delete(Category category);
		Category Update(string idCategory);
		Category GetDetailCategory(string idCategory);

		IEnumerable<Category> GetAll();

	}
}
