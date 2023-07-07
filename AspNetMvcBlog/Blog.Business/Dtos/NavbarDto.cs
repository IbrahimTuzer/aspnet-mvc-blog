using Blog.Business.Dtos;


public class NavbarDto
{
	public IEnumerable<CategoryDto> categories { get; set; }
	public List<PageDto> pages { get; set; }
}
