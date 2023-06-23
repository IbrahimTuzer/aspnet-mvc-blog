using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Business.Dtos;

public class PostImageDto
{
    [Key]
    public int Id { get; set; }
    public int PostId { get; set; }
    public PostDto Post { get; set; }


    [Required]
    [Column(TypeName = "nvarchar(200)")]
    public string? ImagePath { get; set; }
}
