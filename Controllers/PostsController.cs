using m2gil_generateur_blogs.Areas.Identity.Models;
using m2gil_generateur_blogs.Models;
using m2gil_generateur_blogs.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace m2gil_generateur_blogs.Controllers
{
  [Authorize]
  public class PostsController : Controller
  {
    private readonly IPostRepository _postRepository;
    private readonly IBlogRepository _blogRepository;
    private readonly UserManager<ApplicationUser> UserManager;

    public PostsController(IPostRepository postRepository, UserManager<ApplicationUser> userManager, IBlogRepository blogRepository)
    {
      _postRepository = postRepository;
      UserManager = userManager;
      _blogRepository = blogRepository;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
      var blogs = await _postRepository.GetBlogsAsync();
      return View(blogs);
    }

    [Authorize(Roles = "Membre")]
    [HttpPost]
    public async Task<IActionResult> AddPost(Post post)
    { 
      if (!ModelState.IsValid)
      {
        return View(post);
      }

      var userId = UserManager.GetUserId(User);
      post.ApplicationUserId = userId;

      var blog =await _blogRepository.GetUserBlogAsync(userId);
      post.Blog = blog;
      //blog.Posts.Add(post);

      await _postRepository.AddBlogAsync(post);
      await _postRepository.SavesChagesAsync();
      //_blogRepository.SavesChagesAsync();

      return RedirectToAction("Index");
    }

    [Authorize(Roles = "Membre")]
    public IActionResult AddPost()
    {
      var users = UserManager.Users;
      return View();
    }

    [Authorize(Roles = "Administrateur, Membre")]
    public async Task<IActionResult> UpdatePost(int id)
    {
      var post = await _postRepository.GetBlogAsync(id);
      return View(post);
    }

    [Authorize(Roles = "Administrateur, Membre")]

    [HttpPost]
    public async Task<IActionResult> UpdatePost(Post post)
    {
      if (!ModelState.IsValid)
      {
        return View(post);
      }
      var userId = UserManager.GetUserId(User);
      post.ApplicationUserId = userId;
      _postRepository.UpdateBlogAsync(post);
      await _postRepository.SavesChagesAsync();
      return RedirectToAction("UserPosts");
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> PostDetails(int id)
    {
      var post = await _postRepository.GetBlogAsync(id);
      return View(post);
    }

    [Authorize(Roles = "Administrateur, Membre")]
    [HttpGet]
    public async Task<IActionResult> UserPosts()
    {
      
      var userId = UserManager.GetUserId(User);
      var userPosts = await _postRepository.GetUserBlogsAsync(userId);

      var userBlog = await _blogRepository.GetUserBlogAsync(userId);

      if (userBlog == null)
      {
        ViewBag.HasBlog = false;
      }
      else
      {
        ViewBag.HasBlog = true;
      }
      return View(userPosts);
    }

  }
}
