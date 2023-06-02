using Blog.Business.Services.Abstract;
using Blog.Data;
using Blog.Data.Entity;

namespace Blog.Business.Services
{
	public class SettingService : ISettingService
	{
		private readonly AppDbContext _db;
		public SettingService(AppDbContext db)
		{
			_db = db;
		}

		public List<Setting> GetAll()
		{
			return _db.Settings.ToList();

		}

		public Setting GetById(int id)
		{
			return _db.Settings
				.Where(p => p.Id == id)
				.FirstOrDefault();
		}

		public void Insert(Setting setting)
		{
			_db.Settings.Add(setting);
			_db.SaveChanges();
		}

		public void Update(Setting setting)
		{
			var oldSetting = _db.Settings.FirstOrDefault(p => p.Id == setting.Id);
			if (oldSetting != null)
			{
				_db.Entry(oldSetting).CurrentValues.SetValues(setting);
				_db.SaveChanges();
			}
		}

		public void DeleteById(int id)
		{
			var setting = _db.Settings.SingleOrDefault(p => p.Id == id);
			if (setting != null)
			{
				_db.Settings.Remove(setting);
				_db.SaveChanges();
			}
		}

	}
}
