using Blog.Business.Services;
using Blog.Business.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService ps)
        {
            _postService = ps;
        }

        [HttpGet]
        public IEnumerable<PostDto> Get()
        {
            return _postService.GetAll(); // GetAll içindeki Includelar ile birlikte çalıştırılınca hata çıkarıyor
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public PostDto Get(int id)
        {
            return _postService.GetById(id);
        }

        // POST api/<PostController>
        [HttpPost]
        public void Post([FromBody] PostDto post)
        {
            _postService.Insert(post);
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PostDto post)
        {
            _postService.Update(id, post);
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _postService.DeleteById(id);
        }
    }
}
