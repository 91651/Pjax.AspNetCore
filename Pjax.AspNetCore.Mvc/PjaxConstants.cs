using System;

namespace Pjax.AspNetCore.Mvc
{
    public class PjaxConstants
    {
        public const string PjaxHeader = "X-PJAX";
        public const string PjaxUrl = "X-PJAX-URL";
        public const string PjaxVersion = "X-PJAX-VERSION";
        public static readonly string PjaxVersionValue = Guid.NewGuid().ToString("N");
    }
}
