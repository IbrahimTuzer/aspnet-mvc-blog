using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Business.Dtos;

public class CategoryDto
{
    [Key]
    public int Id { get; set; }

	[Column(TypeName = "nvarchar(120)")]
	public string? Slug { get; set; }

	[Required]
    [Column(TypeName ="nvarchar(100)")]
    public string? Name { get; set; }

    [Column(TypeName ="nvarchar(200)")]
    public string? Description { get; set; }
    public List<PostDto>? Posts { get; set; }
}
