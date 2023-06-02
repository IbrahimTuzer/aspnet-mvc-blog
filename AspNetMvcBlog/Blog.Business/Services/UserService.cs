using Blog.Business.Services.Abstract;
using Blog.Data;
using Blog.Data.Entity;
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

		public List<User> GetAll()
		{
			return _db.Users.ToList();

		}

		public User GetById(int id)
		{
			return _db.Users
				.Where(p => p.Id == id)
				.FirstOrDefault();
		}

		public User GetByEmailPassword(string email,string password)
		{
			return _db.Users.FirstOrDefault(e => e.Email == email && e.Password == password);
		}

		public void Insert(User user)
		{
			_db.Users.Add(user);
			_db.SaveChanges();
		}

		public void Update(User user)
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

		public ClaimsPrincipal ConvertToPrincipal(User user)
		{
			var claims = new List<Claim>
					{
						new Claim(ClaimTypes.Name, user.Name),
						new Claim(ClaimTypes.Email, user.Email),
						new Claim("City",user.City),
						new Claim(ClaimTypes.MobilePhone, user.Phone)
					};
			var identity = new ClaimsIdentity(claims, "Cookies");

			return new ClaimsPrincipal(identity);
		}
	}
}
