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

    public  async Task AddBlogAsync(Blog blog)
    {
       await _context.AddAsync(blog);
    }

    public async Task<bool> BlogExistsAsync(int blogId)
    {
      return await _context.Blogs.AnyAsync(b => b.Id == blogId);
    }

    public void DeleteBlog(Blog blog)
    {
      _context.Blogs.Remove(blog);
    }

    public async Task<Blog?> GetBlogAsync(int blogId)
    {
      return await _context.Blogs.Where(b => b.Id == blogId).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Blog>> GetBlogsAsync()
    {
      return await _context.Blogs.Where(b=>b.IsPublished.Equals(true)).ToListAsync();
    }

    public async Task<IEnumerable<Blog>> GetBlogsByDateLimitSixAsync()
    {
      return await _context.Blogs.Where(b=>b.IsPublished.Equals(true)).OrderBy(b=>b.CreatedAt).Take(6).ToListAsync();
    }

    public async Task<IEnumerable<Blog>> GetUserBlogsAsync(string userId)
    {
      return await _context.Blogs.Where(b=>b.ApplicationUserId.Equals(userId)).ToListAsync();
    }

    public async Task<bool> SavesChagesAsync()
    {
      return (await _context.SaveChangesAsync() >= 0);
    }

    public void UpdateBlogAsync(Blog blog)
    {
      _context.Update(blog);  
    }
  }
}
