namespace m2gil_generateur_blogs.Models
{
  public class PostCommentVM
  {
    public Comment Comment { get; set; } = new Comment();
    public Post Post { get; set; } = new Post();
  }
}
