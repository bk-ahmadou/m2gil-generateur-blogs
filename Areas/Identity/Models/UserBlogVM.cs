using m2gil_generateur_blogs.Models;

namespace m2gil_generateur_blogs.Areas.Identity.Models
{
  public class UserBlogVM
  {
    public ApplicationUser ApplicationUser { get; set; }
    public Blog Blog { get; set; }
  }
}
