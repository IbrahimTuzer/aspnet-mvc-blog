using Blog.Business.Dtos;
using Blog.Business.Services;
using Blog.Business.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace Blog.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "Admin")]

	public class BlogController : Controller
    {
        private readonly PostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        public BlogController(PostService ps, ICategoryService cs,IUserService us)
        {
            _postService = ps;
            _categoryService = cs;
            _userService = us;
        }
        public IActionResult Index()
        {
            return View(_postService.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(_postService.GetById(id));
        }
        

        public IActionResult Delete(int id)
        {
            return View(_postService.GetById(id));
        }
        [HttpPost]
        public IActionResult Delete(PostDto p)
        {
            _postService.DeleteById(p.Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var post = _postService.GetById(id);
            if (post != null)
            {
                ViewBag.categories = _categoryService.GetAll();

                return View(post);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Edit(int id, PostDto dto, List<string> categories)
        {
            dto.UserId = 1;
            var cs = new List<CategoryDto>();

            foreach (var category in categories)
            {
                cs.Add(_categoryService.GetById(Convert.ToInt32(category)));
            }
            dto.Categories = cs;
            _postService.Update(id, dto);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Create()
        {
            ViewBag.categories = _categoryService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(PostDto p,List<string> categories)
        {
            p.UserId = 1;
            ModelState.Remove(p.User); // sonra hallet
            if (ModelState.IsValid)
            {
                _postService.Insert(p);   

            return RedirectToAction(nameof(Index));
            }
            ViewBag.categories = _categoryService.GetAll();
            return View(p);
        }
    }
}
