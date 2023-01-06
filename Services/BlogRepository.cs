using m2gil_generateur_blogs.Data;
using m2gil_generateur_blogs.Models;
using Microsoft.EntityFrameworkCore;

namespace m2gil_generateur_blogs.Services
{
  public class BlogRepository : IBlogRepository
  {
    private readonly ApplicationDbContext _context;

    public BlogRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task AddBlogAsync(Blog blog)
    {
      await _context.Blogs.AddAsync(blog);
    }

    public async Task<bool> BlogExistsAsync(int postId)
    {
      return await _context.Posts.AnyAsync(b => b.Id == postId); ;
    }

    public void DeleteBlog(Blog blog)
    {
      throw new NotImplementedException();
    }

    public async Task<Blog?> GetBlogAsync(int blogId)
    {
      return await _context.Blogs.Where(b => b.Id == blogId).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Blog>> GetBlogsAsync()
    {
      return await _context.Blogs.Where(b => b.IsPublic.Equals(true)).ToListAsync();
    }

    public async Task<Blog?> GetUserBlogAsync(string userId)
    {
      return await _context.Blogs.Include(b=>b.Posts).Where(b => b.ApplicationUserId.Equals(userId)).FirstOrDefaultAsync();
    }

    public async Task<bool> SavesChagesAsync()
    {
      return (await _context.SaveChangesAsync() >= 0);
    }

    public void UpdateBlogAsync(Blog blog)
    {
      _context.Update(blog);
    }

    Task<Blog?> IBlogRepository.GetBlogAsync(int blogId)
    {
      throw new NotImplementedException();
    }
  }
}
