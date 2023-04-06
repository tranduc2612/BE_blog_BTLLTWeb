using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BE_blog_BTLLTWeb.Models.Authentication
{
    public class Authentication: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
			
			if (context.HttpContext.Session.GetString("UserName") == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Auth" }, { "Action", "Login" } });
            }

		
		}
    }
}
