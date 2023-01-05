using m2gil_generateur_blogs.Areas.Identity.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace m2gil_generateur_blogs.Models
{
  public class Post
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    //public string OwnerId { get; set; }
    [Required(ErrorMessage = "Le titre est obligatoire")]
    [MaxLength(50)]
    public string Title { get; set; } = string.Empty;
    /*[MaxLength(200)]
    public string Description { get; set; }=string.Empty;*/
    [Required(ErrorMessage = "La category est obligatoire")]
    public string Category { get; set; } = string.Empty;
    [Column(TypeName = "ntext")]
    [Url]
    [Required(ErrorMessage = "L'image est obligatoire")]
    public string ImageUrl { get; set; } = string.Empty;
    public string? Content { get; set; }
    [DefaultValue(false)]
    public Boolean IsPublished { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // user ID from AspNetUser table.
    public string? ApplicationUserId { get; set; }
    ApplicationUser? ApplicationUser { get; set; }
  }
}
