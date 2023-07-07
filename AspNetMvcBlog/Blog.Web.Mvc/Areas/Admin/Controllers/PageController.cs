using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Blog.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "Admin")]

	public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
