using Blog.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Mvc.Controllers
{
    public class BlogController : Controller
    {
        private readonly PostService _ps;

        public BlogController(PostService ps)
        {
            _ps = ps;
        }

        public IActionResult Search(string query, int page = 1)
        {
            var posts = _ps.GetAll()
                .Where(e => e.Title.Contains(query))
                .Skip((page - 1) * 10).Take(10);

            ViewBag.Query = query;

            return View(posts);
        }

        //[Route("/blog/title-slug")]
        public IActionResult Detail(int id)
        {
            var post = _ps.GetById(id);
           if (post == null) { 
            return RedirectToAction("Index","Home");
            }
            return View(post);
        }
    }
}
