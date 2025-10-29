using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace collageproject
{
    public class LoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                var userId = context.HttpContext.Session?.GetString("UserId");

                if (string.IsNullOrEmpty(userId))
                {
                    // For API projects
                    context.Result = new JsonResult(new { message = "Unauthorized - Please login first" })
                    {
                        StatusCode = StatusCodes.Status401Unauthorized
                    };
                }
            }
            catch (Exception ex)
            {
                context.Result = new JsonResult(new { message = $"Login filter error: {ex.Message}" })
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }

            base.OnActionExecuting(context);
        }
    }
}
