using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Mvc.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Search( string query, int page)
        {
            return View();
        }
        [Route("/blog/title-slug")]
        public IActionResult Detail(int id)
        {
            return View();
        }
    }
}
