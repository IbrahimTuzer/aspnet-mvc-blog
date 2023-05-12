using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Mvc.Data.Entity;

public class CategoryPost
{
    [Key]
    public int Id { get; set; }


    public int CategoryId { get; set;}
    public int PostId { get; set; }
}
