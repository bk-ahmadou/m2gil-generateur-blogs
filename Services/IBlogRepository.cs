using m2gil_generateur_blogs.Models;

namespace m2gil_generateur_blogs.Services
{
  public interface IBlogRepository
  {
    Task<IEnumerable<Blog>> GetBlogsAsync();
    Task<Blog?> GetUserBlogAsync(string userId);
    Task<Blog?> GetBlogAsync(int blogId);
    Task<bool> BlogExistsAsync(int postId);
    Task AddBlogAsync(Blog blog);
    void UpdateBlogAsync(Blog blog);
    void DeleteBlog(Blog blog);
    Task<bool> SavesChagesAsync();
  }
}
