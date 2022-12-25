using m2gil_generateur_blogs.Models;
using m2gil_generateur_blogs.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace m2gil_generateur_blogs.Controllers
{
  public class BlogsController : Controller
  {
    private readonly IBlogRepository _blogRepository;

    public BlogsController(IBlogRepository blogRepository)
    {
      _blogRepository = blogRepository;
    }

    public async Task<IActionResult> Index()
    {
      var blogs = await _blogRepository.GetBlogsAsync();
      return View(blogs);
    }

    [HttpPost]
    public async Task<IActionResult> AddBlog(Blog blog)
    {
      if (!ModelState.IsValid)
      {
        return View(blog);
      }
      await _blogRepository.AddBlogAsync(blog);
      await _blogRepository.SavesChagesAsync();
      return RedirectToAction("Index");
    }

    public IActionResult AddBlog()
    {
      return View();
    }
  }
}
