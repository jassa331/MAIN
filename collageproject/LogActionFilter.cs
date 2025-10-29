using collageproject.DAL;
using collageproject.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace collageproject
{
    public class LogActionFilter : ActionFilterAttribute
    {
        private readonly stutentdbcontext _context;
        private DateTime _startTime;

        public LogActionFilter(stutentdbcontext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _startTime = DateTime.Now;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            try
            {
                var duration = (DateTime.Now - _startTime).TotalMilliseconds;

                var user = context.HttpContext.User.Identity?.Name ?? "Anonymous";

                // ✅ Get IP Address
                var ip = context.HttpContext.Connection.RemoteIpAddress?.ToString();

                var log = new ActionLog
                {
                    ControllerName = context.ActionDescriptor.RouteValues["controller"],
                    ActionName = context.ActionDescriptor.RouteValues["action"],
                    UserName = user,
                    UserIp = ip,
                    Timestamp = DateTime.Now,
                    DurationMs = duration
                };

                _context.ActionLogs.Add(log);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LogActionFilter Error] {ex.Message}");
            }
        }
    }
}
