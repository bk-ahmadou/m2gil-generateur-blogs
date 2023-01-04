﻿using m2gil_generateur_blogs.Areas.Identity.Models;
using m2gil_generateur_blogs.Models;
using m2gil_generateur_blogs.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace m2gil_generateur_blogs.Controllers
{
  [Authorize]
  public class BlogsController : Controller
  {
    private readonly IBlogRepository _blogRepository;
    private readonly UserManager<ApplicationUser> UserManager;

    public BlogsController(IBlogRepository blogRepository, UserManager<ApplicationUser> userManager)
    {
      _blogRepository = blogRepository;
      UserManager = userManager;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
      var blogs = await _blogRepository.GetBlogsAsync();
      return View(blogs);
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
      return RedirectToAction("Index");
    }

    [Authorize(Roles = "Administrateur")]
    public IActionResult AddBlog()
    {
      var users = UserManager.Users;
      return View();
    }

    [Authorize(Roles = "Administrateur, Membre")]
    public async Task<IActionResult> UpdateBlog(int id)
    {
      var blog = await _blogRepository.GetBlogAsync(id);
      return View(blog);
    }

    [Authorize(Roles = "Administrateur, Membre")]

    [HttpPost]
    public async Task<IActionResult> UpdateBlog(Blog blog)
    {
      if (!ModelState.IsValid)
      {
        return View(blog);
      }
      var userId = UserManager.GetUserId(User);
      blog.ApplicationUserId = userId;  
      _blogRepository.UpdateBlogAsync(blog);
      await _blogRepository.SavesChagesAsync();
      return RedirectToAction("UserBlogs");
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> BlogDetails(int id)
    {
      var blog = await _blogRepository.GetBlogAsync(id);
      return View(blog);
    }

    [Authorize(Roles = "Administrateur, Membre")]

    [HttpGet]
    public async Task<IActionResult> UserBlogs()
    {
      var userId = UserManager.GetUserId(User);
      var userBlogs = await _blogRepository.GetUserBlogsAsync(userId);
      return View(userBlogs);
    }

  }
}
