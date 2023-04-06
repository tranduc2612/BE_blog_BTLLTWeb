using BE_blog_BTLLTWeb.Models;
using BE_blog_BTLLTWeb.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BE_blog_BTLLTWeb.ViewComponents
{

	public class CategoryViewComponent : ViewComponent
	{
		private readonly ICategoryRepository _Category;

		public CategoryViewComponent(ICategoryRepository category)
		{
			_Category = category;
		}

		public IViewComponentResult Invoke() {
			var category = _Category.GetAll().OrderBy(x => x.NameCategory).Take(5);
			return View(category);
		}
	}
}
