using Microsoft.AspNetCore.Mvc;

namespace m2gil_generateur_blogs.Controllers
{
  public class BlogsController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult AddBlog()
    {
      return View();
    }
  }
}
