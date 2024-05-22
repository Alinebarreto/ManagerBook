using ManagerBook.Application.Services;
using ManagerBook.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManagerBook.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly LoanServices _loanServices;
        public LoansController(LoanServices loanServices)
        {
            _loanServices = loanServices;            
        }

        [HttpGet(Name = "GetAllLoans")]
        public async Task<ActionResult> GetLoans()
        {
            var result = await _loanServices.GetLoansAsync();
            return Ok(result);
        }

        [HttpGet(Name = "GetLoan")]
        public async Task<ActionResult> GetLoan(Guid Id)
        {
            var result = await _loanServices.GetLoanAsync(Id);
            return Ok(result);
        }

        [HttpPost(Name = "AddLoan")]
        public async Task<IActionResult> AddLoanAsync(LoanDTO dto)
        {
            var result = await _loanServices.AddLoanAsync(dto);
            return Ok(result);
        }
        [HttpPut(Name = "UpdateLoan")]
        public async Task<ActionResult> UpdateLoanAsync(LoanDTO dto)
        {
            var result = await _loanServices.UpdateLoanAsync(dto);
            return Ok(result);
        }

        [HttpPost(Name = "PostReturn")]
        public async Task<ActionResult> PostReturnAsync(Guid Id) 
        {
            var result = await _loanServices.ReturnLoanAsync(Id);
            return Ok(result);

        }
    }
}