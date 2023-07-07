using Blog.Business.Services;
using Blog.Business.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.Business.Services.Abstract;

namespace Blog.Web.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly PostService _ps;
        private readonly ICategoryService _categoryService;

        public CategoryController(PostService ps, ICategoryService cs)
        {
            _ps = ps;
            _categoryService = cs;
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

            var category = _categoryService.GetBySlug(slug);
            ViewBag.CategoryName = category.Name;

            return View(posts);
        }
    }
}
