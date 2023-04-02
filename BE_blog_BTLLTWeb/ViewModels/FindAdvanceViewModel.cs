using BE_blog_BTLLTWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BE_blog_BTLLTWeb.ViewModels
{
	public class FindAdvanceViewModel
	{
		BlogBtlContext db = new BlogBtlContext();
		private List<Blog> listResult;
		public FindAdvanceViewModel(string postname,string authorpost,string date)
		{
			var listForAdvance = db.Blogs.ToList();

			if (date != null && postname != null)
			{
				var newDate = date.Trim().Split("to");
				DateTime beginDate = DateTime.Parse(newDate[0]);
				DateTime endDate = DateTime.Parse(newDate[1]);
				listForAdvance = listForAdvance.Where(x => x.CreateAt >= beginDate && x.CreateAt <= endDate && x.Title.Contains(postname)).ToList();
			}else if(date != null)
			{

				var newDate = date.Trim().Split("to");
				DateTime beginDate = DateTime.Parse(newDate[0]);
				DateTime endDate = DateTime.Parse(newDate[1]);
				listForAdvance = listForAdvance.Where(x => x.CreateAt >= beginDate && x.CreateAt <= endDate).ToList();

			}
			else if(postname != null) { 
				listForAdvance = listForAdvance.Where(x => x.Title.Contains(postname)).ToList();
			}
			

			List<Blog> newList = new List<Blog>();
			if(authorpost != null && listForAdvance.Count != 0)
			{
				var listForAuthor = db.Accounts.Where(x => x.Fullname.Contains(authorpost)).ToList();
				
				foreach(var blog in listForAdvance)
				{
					int temp = 0;
					foreach (var author in listForAuthor)
					{
						if(blog.IdAccount == author.IdAccount)
						{
							temp++;
						}
					}
					if(temp != 0)
					{
						newList.Add(blog);
					}
				}
				ListResult = newList;
			}
			else
			{
				ListResult = listForAdvance;
			}

		}

		public List<Blog> ListResult { get => listResult; set => listResult = value; }
	}
}
