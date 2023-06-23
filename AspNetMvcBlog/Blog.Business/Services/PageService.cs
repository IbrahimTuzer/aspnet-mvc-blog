using Blog.Business.Services.Abstract;
using Blog.Data;
using Blog.Business.Dtos;


namespace Blog.Business.Services
{
	public class PageService : IPageService
	{
		private readonly AppDbContext _db;
		public PageService(AppDbContext db)
		{
			_db = db;
		}

		public List<PageDto> GetAll()
		{
			return _db.Pages.ToList().PageListToDtoList();

		}

		public PageDto GetById(int id)
		{
			return _db.Pages
				.Where(p => p.Id == id)
				.FirstOrDefault().PageToDto();
		}

		public void Insert(PageDto page)
		{
			_db.Pages.Add(page.DtoToPage());
			_db.SaveChanges();
		}

		public void Update(PageDto page)
		{
			var oldPage = _db.Pages.FirstOrDefault(p => p.Id == page.Id);
			if (oldPage != null)
			{
				_db.Entry(oldPage).CurrentValues.SetValues(page);
				_db.SaveChanges();
			}
		}

		public void DeleteById(int id)
		{
			var page = _db.Pages.SingleOrDefault(p => p.Id == id);
			if (page != null)
			{
				_db.Pages.Remove(page);
				_db.SaveChanges();
			}
		}

	}
}
