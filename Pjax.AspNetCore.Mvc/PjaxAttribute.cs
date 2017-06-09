using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Pjax.AspNetCore.Mvc
{
    public class PjaxAttribute : ActionFilterAttribute
    {
        public bool IsPjax { get; set; }

        public PjaxAttribute(bool isPjax = true)
        {
            IsPjax = isPjax;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!IsPjax)
            {
                return;
            }
            var pjaxController = (Controller)filterContext.Controller;
            var pjax = filterContext.HttpContext.Request.Headers[PjaxConstants.PjaxHeader];
            pjaxController.ViewBag.IsPjaxRequest = bool.TryParse(pjax, out var isPjaxRequest) && isPjaxRequest;
            pjaxController.ViewBag.PjaxVersion = PjaxConstants.PjaxVersionValue;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!IsPjax)
            {
                return;
            }
            var pjaxController = (Controller)filterContext.Controller;
            if (!pjaxController.ViewBag.IsPjaxRequest)
            {
                return;
            }
            if (!filterContext.HttpContext.Response.Headers.ContainsKey(PjaxConstants.PjaxVersion))
            {
                filterContext.HttpContext.Response.Headers.Add(PjaxConstants.PjaxVersion, PjaxConstants.PjaxVersionValue);
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Response.StatusCode != StatusCodes.Status200OK && !filterContext.HttpContext.Response.Headers.ContainsKey(PjaxConstants.PjaxUrl))
            {
                var url = filterContext.HttpContext.Request.Path.Value;
                filterContext.HttpContext.Response.Headers.Add(PjaxConstants.PjaxUrl, url);
            }
        }
    }
}