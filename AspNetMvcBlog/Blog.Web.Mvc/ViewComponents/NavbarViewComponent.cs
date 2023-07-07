using Blog.Business.Services;
using Blog.Business.Services.Abstract;
using Blog.Data;
using Blog.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Mvc.ViewComponents;

public class NavbarViewComponent : ViewComponent
{
	private readonly ICategoryService _cs;
	private readonly PageService _pageService;

	public NavbarViewComponent(ICategoryService cs,PageService pageService)
	{
		_cs = cs;
		_pageService = pageService;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		//AppDbContext Db;
		//db = Db;

		return View(
			new NavbarDto
			{
				categories = _cs.GetAll(),
				pages = _pageService.GetAll()
			}
			);
		//return View();
	}
}
