using Blog.Web.Mvc.Data.Entity.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Web.Mvc.Data.Entity;

public class Post : AuditEntity
{
	[Key]
	public int Id { get; set; }

	[Required]
	public int UserId { get; set; }

	[Required]
	[Column(TypeName = "nvarchar(200)")]
	public string? Title { get; set; }

	[Required]
	[Column(TypeName = "ntext")]
	public string? Content { get; set; }
}
