using m2gil_generateur_blogs.Areas.Identity.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace m2gil_generateur_blogs.Models
{
  public class Blog
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    //public string OwnerId { get; set; }
    [Required(ErrorMessage = "Le titre est obligatoire")]
    [MaxLength(64)]
    public string Title { get; set; } = string.Empty;
    [MaxLength(200)]
    public string Description { get; set; }=string.Empty;
    [DefaultValue(true)]
    public Boolean IsPublic { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // user ID from AspNetUser table.
    public string ApplicationUserId { get; set; }
    ApplicationUser ApplicationUser { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
  }
}
