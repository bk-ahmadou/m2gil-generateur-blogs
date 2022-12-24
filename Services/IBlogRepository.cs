using m2gil_generateur_blogs.Models;

namespace m2gil_generateur_blogs.Services
{
  public interface IBlogRepository
  {
    Task<IEnumerable<Blog>> GetBlogsAsync();
    Task<Blog?> GetBlogAsync(int blogId);
    Task<bool> BlogExistsAsync(int blogId);
    Task AddBlogAsync(Blog blog);
    void DeleteBlog(Blog blog);
    Task<bool> SavesChagesAsync();
  }
}
