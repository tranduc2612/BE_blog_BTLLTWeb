using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BE_blog_BTLLTWeb.Areas.Admin.Models
{
	public class AuthenticationAdmin: ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			base.OnActionExecuted(context);
			if (context.HttpContext.Session.GetString("Admin") == null)
			{
				context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Auth" }, { "Action", "Login"}});
			}
		}
	}
}
