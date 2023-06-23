using Blog.Business.Services;
using Blog.Business.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly PostService _ps;
        private readonly CategoryService _cs;

        public CategoryController(PostService ps,CategoryService cs)
        {
            _ps = ps;
            _cs = cs;
        }

        // /category/index/1
        // /category/software
        [Route("/category/{slug}", Name = "CategorySlug")]
        public IActionResult Index(string slug, int page = 1)
        {
            var posts = _ps.GetAll()
                .Where(e => e.Categories.Any(e => e.Slug == slug))
                .Skip((page - 1) * 10).Take(10)
                .ToList();

            var category = _cs.GetBySlug(slug);
            ViewBag.CategoryName = category.Name;

            return View(posts);
        }
    }
}
