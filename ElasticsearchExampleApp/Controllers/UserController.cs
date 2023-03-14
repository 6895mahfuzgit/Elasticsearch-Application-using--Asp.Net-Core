using ElasticsearchExampleApp.Models;
using ElasticsearchExampleApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElasticsearchExampleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet()]
        public async Task<List<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }


        [HttpGet("{id}")]
        public async Task<User> Get(string id)
        {
            return await _userRepository.Get(id);
        }

        [HttpPost]
        public async Task<User> Post(User user)
        {
            return await _userRepository.Save(user);
        }

    }
}
