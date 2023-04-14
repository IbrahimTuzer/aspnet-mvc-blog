using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Mvc.Controllers
{
    public class PageController : Controller
    {
        [Route("/page/title-slug")]
        public IActionResult Detail(int id)
        {
            return View();
        }
    }
}
