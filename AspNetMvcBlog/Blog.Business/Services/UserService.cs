using Blog.Business.Services.Abstract;
using Blog.Data;
using Blog.Business.Dtos;
using System.Net;
using System.Security.Claims;

namespace Blog.Business.Services
{
	public class UserService : IUserService
	{
		private readonly AppDbContext _db;
		public UserService(AppDbContext db)
		{
			_db = db;
		}

		public List<UserDto> GetAll()
		{
			return _db.Users.ToList().UserListToDtoList();

		}

		public UserDto GetById(int id)
		{
			return _db.Users
				.Where(p => p.Id == id)
				.FirstOrDefault().UserToDto();
		}

		public UserDto GetByEmailPassword(string email,string password)
		{
			return _db.Users.FirstOrDefault(e => e.Email == email && e.Password == password).UserToDto();
		}

		public void Insert(UserDto user)
		{
			_db.Users.Add(user.DtoToUser());
			_db.SaveChanges();
		}

		public void Update(UserDto user)
		{
			var oldUser = _db.Users.FirstOrDefault(p => p.Id == user.Id);
			if (oldUser != null)
			{
				_db.Entry(oldUser).CurrentValues.SetValues(user);
				_db.SaveChanges();
			}
		}

		public void DeleteById(int id)
		{
			var user = _db.Users.SingleOrDefault(p => p.Id == id);
			if (user != null)
			{
				_db.Users.Remove(user);
				_db.SaveChanges();
			}
		}

		public ClaimsPrincipal ConvertToPrincipal(UserDto user)
		{
			var claims = new List<Claim>
					{
						new Claim(ClaimTypes.Name, user.Name),
						new Claim(ClaimTypes.Email, user.Email),
						new Claim("City",user.City),
						new Claim(ClaimTypes.MobilePhone, user.Phone)
					};

			if (!string.IsNullOrEmpty(user.Roles))
			{
				string[] roles = user.Roles.Substring(0,user.Roles.Length-1).Split(','); // Admin,Student
				foreach (var role in roles)
				{
					claims.Add(new Claim(ClaimTypes.Role, role));
				}
			}

			var identity = new ClaimsIdentity(claims, "Cookies");

			return new ClaimsPrincipal(identity);
		}
	}
}
