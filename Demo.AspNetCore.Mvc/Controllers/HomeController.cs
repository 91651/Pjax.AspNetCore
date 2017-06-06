using Microsoft.AspNetCore.Mvc;
using Pjax.AspNetCore.Mvc;

namespace Demo.AspNetCore.Mvc.Controllers
{
    //[Pjax]
    public class HomeController : Controller
    {
        [Pjax]
        public IActionResult Index()
        {
            ViewData["Message"] = "View Index";
            return View();
        }
        [Pjax]
        public IActionResult View1()
        {
            ViewData["Message"] = "View1";

            return View();
        }
        [Pjax]
        public IActionResult View2()
        {
            ViewData["Message"] = "View2";

            return View();
        }
        public IActionResult View3()
        {
            ViewData["Message"] = "View3 (No Pjax)";

            return View();
        }

    }
}
