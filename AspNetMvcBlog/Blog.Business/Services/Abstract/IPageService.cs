using Blog.Business.Dtos;


namespace Blog.Business.Services.Abstract
{
	public interface IPageService
	{
		List<PageDto> GetAll();
		PageDto GetById(int id);
		void Insert(PageDto page);
		void Update(PageDto page);
		void DeleteById(int id);
	}
}
