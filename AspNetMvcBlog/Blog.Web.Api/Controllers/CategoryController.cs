using Blog.Business.Services;
using Blog.Business.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
            public CategoryController( CategoryService cs)
        {
            _categoryService = cs;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<CategoryDto> Get()
        {
            return _categoryService.GetAll();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public CategoryDto Get(int id)
        {
            return _categoryService.GetById(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] CategoryDto c)
        {
            _categoryService.Insert(c);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CategoryDto c)
        {
            _categoryService.Update(c);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryService.DeleteById(id);
        }
    }
}
