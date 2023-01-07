using m2gil_generateur_blogs.Areas.Identity.Models;
using m2gil_generateur_blogs.Models;
using m2gil_generateur_blogs.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace m2gil_generateur_blogs.Controllers
{
  [Authorize]
  public class BlogsController : Controller
  {
    private readonly IBlogRepository _blogRepository;
    private readonly UserManager<ApplicationUser> UserManager;
    private readonly RoleManager<IdentityRole> RoleManager;

    public BlogsController(IBlogRepository blogRepository, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
      _blogRepository = blogRepository;
      UserManager = userManager;
      RoleManager = roleManager;
    }
    public IActionResult Index()
    {
      return View();
    }

    [Authorize(Roles = "Administrateur")]
    public IActionResult AddBlog()
    {
      var users = UserManager.Users;
      return View();
    }

    [Authorize(Roles = "Administrateur")]
    [HttpPost]
    public async Task<IActionResult> AddBlog(Blog blog)
    {
      if (!ModelState.IsValid)
      {
        return View(blog);
      }


      await _blogRepository.AddBlogAsync(blog);
      await _blogRepository.SavesChagesAsync();

      return RedirectToAction("Index", "Posts");
    }
  }
}
