using ManagerBook.Application.Services;
using ManagerBook.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManagerBook.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserServices _userServices;
        public UsersController(UserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost(Name = "AddUser")]
        public async Task<IActionResult>AddUserAsync(UserDTO dto) 
        {
            var result = await _userServices.AddUserAsync(dto);
            return Ok(result);

        }

        [HttpGet(Name = "GetUsers")]
        public async Task<ActionResult> GetUsers()
        {
            var result = await _userServices.GetUsersAsync();
            return Ok(result);
        }

        [HttpGet(Name = "GetUser")]
        public async Task<ActionResult> GetUser(Guid Id)
        {
            var result = await _userServices.GetUserAsync(Id);
            return Ok(result);
        }
    }
}

