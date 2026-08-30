using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StaffManagementApp.Filters
{
    public class RequireAdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var isAuthenticated = context.HttpContext.Session.GetString("IsAuthenticated");

            if (isAuthenticated != "true")
            {
                context.Result = new RedirectToActionResult("Login", "Access", null);
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
