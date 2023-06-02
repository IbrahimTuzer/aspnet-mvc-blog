using Blog.Data.Entity;

namespace Blog.Business.Services.Abstract
{
	public interface IPageService
	{
		List<Page> GetAll();
		Page GetById(int id);
		void Insert(Page page);
		void Update(Page page);
		void DeleteById(int id);
	}
}
