using Microsoft.AspNetCore.Identity;

namespace m2gil_generateur_blogs.Areas.Identity.Models
{
  public class ApplicationUser : IdentityUser
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}
