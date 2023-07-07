using Blog.Business.Dtos;
using Blog.Business.Services;
using Blog.Business.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Blog.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "Admin")]

	public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService cs)
        {
            _categoryService = cs;
        }

        public IActionResult Index()
        {
            return View(_categoryService.GetAll());
        }

        public IActionResult Details(int id)
        {

            return View(_categoryService.GetById(id));
        }
        public IActionResult Edit(int id)
        {
            return View(_categoryService.GetById(id));

        }
        [HttpPost]
        public IActionResult Edit(CategoryDto c)
        {
            _categoryService.Update(c);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int id)
        {
            return View(_categoryService.GetById(id));

        }
        [HttpPost]
        public IActionResult Delete(CategoryDto c)
        {
            _categoryService.DeleteById(c.Id);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(CategoryDto c)
        {
            if (ModelState.IsValid) { 
            _categoryService.Insert(c);
            
            return RedirectToAction(nameof(Index));
            }
            return View(c);
        }
    }
}
