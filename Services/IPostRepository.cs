using m2gil_generateur_blogs.Models;

namespace m2gil_generateur_blogs.Services
{
  public interface IPostRepository
  {
    Task<IEnumerable<Post>> GetBlogsAsync();
    Task<IEnumerable<Post>> GetBlogsByDateLimitSixAsync();
    Task<IEnumerable<Post>> GetUserBlogsAsync(string userId);
    Task<Post?> GetBlogAsync(int postId);
    Task<bool> BlogExistsAsync(int postId);
    Task AddBlogAsync(Post post);
    void UpdateBlogAsync(Post post);
    void DeleteBlog(Post post);
    Task<bool> SavesChagesAsync();

    Task AddComment(Comment comment);
  }
}
