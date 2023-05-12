using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Web.Mvc.Data.Entity;

public class PostImage
{
    [Key]
    public int Id { get; set; }
    public int PostId { get; set; }


    [Required]
    [Column(TypeName = "nvarchar(200)")]
    public string? ImagePath { get; set; }
}
