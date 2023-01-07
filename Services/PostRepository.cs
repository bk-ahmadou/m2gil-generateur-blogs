using m2gil_generateur_blogs.Data;
using m2gil_generateur_blogs.Models;
using Microsoft.EntityFrameworkCore;

namespace m2gil_generateur_blogs.Services
{
  public class PostRepository : IPostRepository
  {
    private readonly ApplicationDbContext _context;

    public PostRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public  async Task AddComment(Comment comment)
    {
       await _context.Comments.AddAsync(comment);
    }

    public async Task AddBlogAsync(Post post)
    {
      await _context.Posts.AddAsync(post);
    }

    //This methode Verify if Blog exists
    public async Task<bool> BlogExistsAsync(int postId)
    {
      return await _context.Posts.AnyAsync(b => b.Id == postId);
    }

    public void DeleteBlog(Post post)
    {
      _context.Posts.Remove(post);
    }

    //This
    public async Task<Post?> GetBlogAsync(int postId)
    {
      return await _context.Posts.Where(b => b.Id == postId).Include(b=>b.Comments).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Post>> GetBlogsAsync()
    {
      return await _context.Posts.Where(b=>b.IsPublished.Equals(true)).ToListAsync();
    }

    public async Task<IEnumerable<Post>> GetBlogsByDateLimitSixAsync()
    {
      return await _context.Posts.Where(b=>b.IsPublished.Equals(true)).OrderBy(b=>b.CreatedAt).Take(6).ToListAsync();
    }

    public async Task<IEnumerable<Post>> GetUserBlogsAsync(string userId)
    {
      return await _context.Posts.Where(b=>b.ApplicationUserId.Equals(userId)).ToListAsync();
    }

    public async Task<bool> SavesChagesAsync()
    {
      return (await _context.SaveChangesAsync() >= 0);
    }

    public void UpdateBlogAsync(Post post)
    {
      _context.Update(post);  
    }
  }
}
