using Blog.Business.Services;
using Blog.Data.Entity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly SettingService _settingService;
        public SettingController(SettingService ss)
        {
            _settingService = ss;
        }

        // GET: api/<SettingController>
        [HttpGet]
        public List<SettingDto> Get()
        {
            return _settingService.GetAll();
        }

        // GET api/<SettingController>/5
        [HttpGet("{id}")]
        public SettingDto Get(int id)
        {
            return _settingService.GetById(id);
        }

        // POST api/<SettingController>
        [HttpPost]
        public void Post([FromBody] SettingDto setting)
        {
            _settingService.Insert(setting);
        }

        // PUT api/<SettingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SettingDto setting)
        {
            _settingService.Update(setting);
        }

        // DELETE api/<SettingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _settingService.DeleteById(id);
        }
    }
}
