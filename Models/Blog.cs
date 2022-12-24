using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace m2gil_generateur_blogs.Models
{
  public class Blog
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    //public string OwnerId { get; set; }
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }=string.Empty;
    /*[MaxLength(200)]
    public string Description { get; set; }=string.Empty;*/
    [Required]
    public string Category { get; set; }=string.Empty;
    [Column(TypeName ="ntext")]
    [Url]
    public string ImageUrl { get; set; }  = string.Empty;
    public string Content { get; set; } = string.Empty;
    [Timestamp]
    public DateTime CreatedAt { get; set; }
  }
}
