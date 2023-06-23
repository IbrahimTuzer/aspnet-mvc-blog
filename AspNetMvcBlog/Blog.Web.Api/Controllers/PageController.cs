using Blog.Business.Services;
using Blog.Business.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly PageService _pageService;
        public PageController(PageService ps)
        {
            _pageService = ps;
        }

        // GET: api/<PageController>
        [HttpGet]
        public List<PageDto> Get()
        {
            return _pageService.GetAll();
        }

        // GET api/<PageController>/5
        [HttpGet("{id}")]
        public PageDto Get(int id)
        {
            return _pageService.GetById(id);
        }

        // POST api/<PageController>
        [HttpPost]
        public void Post([FromBody] PageDto page)
        {
            _pageService.Insert(page);
        }

        // PUT api/<PageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PageDto page)
        {
            _pageService.Update(page);
        }

        // DELETE api/<PageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _pageService.DeleteById(id);
        }
    }
}
