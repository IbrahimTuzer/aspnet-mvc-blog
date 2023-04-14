using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        [Route("/category/category-slug")]
        public IActionResult Index( int id,int page)
        {
            return View();
        }
    }
}
