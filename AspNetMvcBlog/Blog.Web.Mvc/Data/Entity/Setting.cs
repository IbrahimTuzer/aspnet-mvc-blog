using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Web.Mvc.Data.Entity;

public class Setting
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string? Name { get; set; }

    [Column(TypeName = "nvarchar(400)")]
    public string? Value { get; set; }
}
