using m2gil_generateur_blogs.Models;
using Microsoft.AspNetCore.Mvc;

namespace m2gil_generateur_blogs.Controllers
{
  public class BlogsController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult AddBlog(Blog blog)
    {
      int id = blog.Id;
      return View();
    }
  }
}
