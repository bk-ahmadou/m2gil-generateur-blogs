using m2gil_generateur_blogs.Areas.Identity.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace m2gil_generateur_blogs.Models
{
  public class Comment
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Value { get; set; }
    public Post? Post { get; set; }
    public ApplicationUser? User { get; set; }
  }
}
