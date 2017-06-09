using Microsoft.AspNetCore.Mvc;
using Pjax.AspNetCore.Mvc;

namespace Demo.AspNetCore.Mvc.Controllers
{
    //[Pjax]
    public class HomeController : Controller
    {
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

        [Pjax(false)]
        public IActionResult View3()
        {
            ViewData["Message"] = "Pjax(false)";

            return View();
        }

        public IActionResult View4()
        {
            ViewData["Message"] = "View4 (No Pjax)";

            return View();
        }

        [Pjax]
        public IActionResult View5()
        {
            ViewData["Message"] = "View5";

            return RedirectToAction("View2");
        }
    }
}