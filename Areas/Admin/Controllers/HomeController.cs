using Microsoft.AspNetCore.Mvc;

namespace m2gil_generateur_blogs.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
