using ManagerBook.Application.Services;
using ManagerBook.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManagerBook.API.Controllers
{
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly LoanServices _loanServices;
        public LoansController(LoanServices loanServices)
        {
            _loanServices = loanServices;            
        }

        [HttpGet]
        [Route("api/Loans/")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _loanServices.GetAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("api/Loans/{id=id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var result = await _loanServices.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("api/Loans/")]
        public async Task<IActionResult> AddAsync(LoanDTO dto)
        {
            var result = await _loanServices.AddAsync(dto);

            return Ok(result);
        }

        [HttpPut]
        [Route("api/Loans/{id=id}")]
        public async Task<ActionResult> UpdateReturnDateAsync(Guid id, DateTime updateDate)
        {
            var result = await _loanServices.UpdateReturnDateAsync(id, updateDate);

            return Ok(result);
        }

        [HttpPatch]
        [Route("api/Loans/Return/{id=id}")]
        public async Task<ActionResult> ReturnAsync(Guid id) 
        {
            var result = await _loanServices.ReturnAsync(id);

            return Ok(result);

        }
    }
}