using m2gil_generateur_blogs.Areas.Identity.Models;
using m2gil_generateur_blogs.Models;
using m2gil_generateur_blogs.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace m2gil_generateur_blogs.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IBlogRepository _blogRepository;

    public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, IBlogRepository blogRepository = null)
    {
      _userManager = userManager;
      _logger = logger;
      _blogRepository = blogRepository;
    }

    public async Task<IActionResult> Index()
    {
      var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
      var blogs = await _blogRepository.GetBlogsAsync();
      //return RedirectToAction()
      return View(blogs);
    }

    public IActionResult Privacy()
    {
      return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}