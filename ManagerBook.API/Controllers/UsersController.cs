using ManagerBook.Application.Services;
using ManagerBook.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManagerBook.API.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly UserServices _userServices;
        public UsersController(UserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        [Route("api/Users/")]
        public async Task<IActionResult>AddAsync(UserDTO dto) 
        {
            var result = await _userServices.AddAsync(dto);

            return Ok(result);

        }

        [HttpGet]
        [Route("api/Users/")]
        public async Task<ActionResult> Get()
        {
            var result = await _userServices.GetAll();

            return Ok(result);
        }

        [HttpGet]
        [Route("api/Users/{id=id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var result = await _userServices.GetByIdAsync(id);

            return Ok(result);
        }
    }
}

