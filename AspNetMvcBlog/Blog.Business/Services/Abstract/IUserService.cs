using Blog.Data.Entity;

namespace Blog.Business.Services.Abstract
{
	public interface IUserService
	{
		List<User> GetAll();
		User GetById(int id);
		void Insert(User user);
		void Update(User user);
		void DeleteById(int id);
	}
}
