using Blog.Data.Entity;

namespace Blog.Business.Services.Abstract
{
	public interface ISettingService
	{
		List<Setting> GetAll();
		Setting GetById(int id);
		void Insert(Setting setting);
		void Update(Setting setting);
		void DeleteById(int id);
	}
}
