using Blog.Data.Entity;
using Blog.Data.Entity.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Business.Dtos;


public class PostDto : AuditEntity
{
	[Key]
	public int Id { get; set; }

	
	public int UserId { get; set; }
	public UserDto User { get; set; }


	[Required]
	[Column(TypeName = "nvarchar(100)")]
	public string? Title { get; set; }

	[Required]
	[Column(TypeName = "nvarchar(max)")]
	public string? Content { get; set; }

	// Navigation Properties
	public List<CategoryDto>? Categories { get; set; }
}
