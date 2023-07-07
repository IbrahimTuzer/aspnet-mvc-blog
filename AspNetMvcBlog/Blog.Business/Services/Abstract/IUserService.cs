using Blog.Business.Dtos;
using System.Security.Claims;

namespace Blog.Business.Services.Abstract
{
	public interface IUserService
	{
		List<UserDto> GetAll();
		UserDto GetById(int id);
		UserDto GetByEmailPassword(string email, string password);

        void Insert(UserDto user);
		void Update(UserDto user);
		void DeleteById(int id);
		ClaimsPrincipal ConvertToPrincipal(UserDto user);

    }
}
