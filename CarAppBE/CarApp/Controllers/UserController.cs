using CarApp.Business;
using CarApp.Business.DTO;
using CarApp.Business.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarApp.Controllers
{
    [ApiController]
    [Route("/Api/[controller]")]
    public class UserController : ControllerBase
    {
        private UserHandler userHandler;

        public UserController(UserHandler userHandler)
        {
            this.userHandler = userHandler;
        }

        [HttpPut("Login")]
        public async Task<bool> Login(UserDto dto)
        {
            return await userHandler.Login(dto);
        }

        [HttpPut("Logout")]
        public async Task<bool> Logout()
        {
            return await userHandler.Logout();
        }

        [HttpPost("Register")]
        public async Task Register(UserDto dto)
        {
            await userHandler.Register(dto);
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await userHandler.GetAll();
        }
    }
}
