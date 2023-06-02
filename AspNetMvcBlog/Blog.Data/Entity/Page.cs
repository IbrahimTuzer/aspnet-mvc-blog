using Blog.Data.Entity.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.Entity;

public class Page : AuditEntity
{
	[Key]
	public int Id { get; set; }

	[Column(TypeName = "nvarchar(120)")]
	public string? Slug { get; set; }

	[Required]
	public string? Title { get; set; }

	//[Required]
	[Column(TypeName = "text")]
	public string? Content { get; set; }

	public bool IsActive { get; set; }
}
