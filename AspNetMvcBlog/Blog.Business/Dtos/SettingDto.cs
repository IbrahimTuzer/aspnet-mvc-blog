using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Blog.Business.Dtos;


public class SettingDto
{
    [Key]
    public int Id { get; set; }
    public int? UserId { get; set; }
    public UserDto? User { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string? Name { get; set; }

    [Column(TypeName = "nvarchar(400)")]
    public string? Value { get; set; }
}
