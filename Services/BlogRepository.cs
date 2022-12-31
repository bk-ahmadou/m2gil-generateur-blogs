using m2gil_generateur_blogs.Models;
using m2gil_generateur_blogs.Repositories;
using Microsoft.EntityFrameworkCore;

namespace m2gil_generateur_blogs.Services
{
  public class BlogRepository : IBlogRepository
  {
    private readonly BlogsDbContext _context;

    public BlogRepository(BlogsDbContext context)
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
      return await _context.Blogs.ToListAsync();
    }

    public Task<IEnumerable<Blog>> GetUserBlogsAsync()
    {
      throw new NotImplementedException();
    }

    public async Task<bool> SavesChagesAsync()
    {
      return (await _context.SaveChangesAsync() >= 0);
    }
  }
}
