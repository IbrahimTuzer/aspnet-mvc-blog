using Blog.Web.Mvc.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        // /category/index/1
        // /category/software
        [Route("/category/{slug}", Name = "CategorySlug")]
        public IActionResult Index(string slug, int page = 1)
        {
            var posts = _db.Posts
                .Include(p => p.Category)
                .Where(e => e.Category.Slug == slug)
                .Skip((page - 1) * 10).Take(10)
                .ToList();

            var category = _db.Categories.Where(e => e.Slug == slug).FirstOrDefault();
            ViewBag.CategoryName = category.Name;

            return View(posts);
        }
    }
}
