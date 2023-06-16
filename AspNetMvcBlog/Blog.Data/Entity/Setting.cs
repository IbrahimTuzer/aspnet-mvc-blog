using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.Entity;

public class Setting
{
    [Key]
    public int Id { get; set; }
    public int? UserId { get; set; }
    public User? User { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string? Name { get; set; }

    [Column(TypeName = "nvarchar(400)")]
    public string? Value { get; set; }
}
