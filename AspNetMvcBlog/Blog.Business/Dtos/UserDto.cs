using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Business.Dtos;

public class UserDto
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string? Name { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string? Email { get; set; }

    [Column(TypeName = "nvarchar(100)")]

    public string? City { get; set; }

    [Column(TypeName = "nvarchar(100)")]

    public string? Password { get; set; }

    [Column(TypeName = "varchar(20)")]
    public string? Phone { get; set; }

    public string? Roles { get; set; }
}
