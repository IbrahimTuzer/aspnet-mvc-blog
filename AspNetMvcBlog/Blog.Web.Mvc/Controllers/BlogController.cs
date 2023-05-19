using Blog.Web.Mvc.Data;
using Blog.Web.Mvc.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Mvc.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;

        public BlogController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Search(string query, int page = 1)
        {
            var posts = _db.Posts
                .Include(p => p.Category)
                .Where(e => e.Title.Contains(query))
                .Skip((page - 1) * 10).Take(10)
                .ToList();

            ViewBag.Query = query;

            return View(posts);
        }

        //[Route("/blog/title-slug")]
        public IActionResult Detail(int id)
        {
            Post post = _db.Posts
                .Include(p => p.Category)
                .Include(p => p.User)
                .Where(p=> p.Id == id)
                .FirstOrDefault();
           if (post == null) { 
            return RedirectToAction("Index","Home");
            }
            return View(post);
        }
    }
}
