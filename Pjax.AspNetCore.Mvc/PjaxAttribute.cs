using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Pjax.AspNetCore.Mvc
{
    public class PjaxAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var pjaxController = (Controller)filterContext.Controller;
            var pjax = filterContext.HttpContext.Request.Headers[PjaxConstants.PjaxHeader];
            pjaxController.ViewBag.IsPjaxRequest = bool.TryParse(pjax, out var isPjaxRequest) && isPjaxRequest;
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var pjaxController = (Controller)filterContext.Controller;
            if (!pjaxController.ViewBag.IsPjaxRequest)
            {
                return;
            }
            if (!filterContext.HttpContext.Response.Headers.ContainsKey(PjaxConstants.PjaxUrl))
            {
                var url = filterContext.HttpContext.Request.Path.Value;
                filterContext.HttpContext.Response.Headers.Add("X-PJAX-URL", url);
            }

        }
    }
}
