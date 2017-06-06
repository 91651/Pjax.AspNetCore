
**Pjax.AspNetCore**

Develop .net core application with Jquery.Pjax (https://github.com/defunkt/jquery-pjax).


**Usage**

* View Layout

```
  @if (ViewBag.IsPjaxRequest ?? false)
  {
    <title>@ViewData["Title"]</title>
    @RenderBody()
    @RenderSection("Scripts", false)
    return;
  }
```

* [Pjax]

* * Controller

```
    [Pjax]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
```

`Or`
  
* * Action

```
    [Pjax]
     public IActionResult Index()
     {
         ViewData["Message"] = "View Index";
         return View();
     }
```
**LICENSE**
MIT

