using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace asp.net_mvc.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService { get; set; }

        public UserController(UserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public ICollection<User> Get()
        {
            return _userService.GetAllUsers().ToList();
        }


        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
