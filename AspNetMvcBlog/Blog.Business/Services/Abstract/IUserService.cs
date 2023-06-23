using Blog.Business.Dtos;


namespace Blog.Business.Services.Abstract
{
	public interface IUserService
	{
		List<UserDto> GetAll();
		UserDto GetById(int id);
		void Insert(UserDto user);
		void Update(UserDto user);
		void DeleteById(int id);
	}
}
