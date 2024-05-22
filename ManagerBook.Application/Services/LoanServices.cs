using ManagerBook.Core.Entities;
using ManagerBook.DTO;
using ManagerBook.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ManagerBook.Application.Services
{
    public class LoanServices
    {
        private readonly ManagerBookDbContext _managerBookDbContext;

        public LoanServices(ManagerBookDbContext managerBookDbContext)

        {
            _managerBookDbContext = managerBookDbContext;
        }
        public async Task<Loan> AddLoanAsync(LoanDTO loanDTO)
        {
            var loan = new Loan
            {
                Id = loanDTO.Id,
                UserId = loanDTO.UserId,
                BookId = loanDTO.BookId,
                LoanDate = loanDTO.LoanDate,
                ReturnDate = loanDTO.ReturnDate
            };

            var result = await _managerBookDbContext.Loans.AddAsync(loan);
            await _managerBookDbContext.SaveChangesAsync();
            return loan;
        }

        public async Task<List<Loan>> GetLoansAsync()
        {
            var result = await _managerBookDbContext.Loans.ToListAsync();
            return result;
        }

        public async Task<Loan> GetLoanAsync(Guid Id)
        {
            var result = await _managerBookDbContext.Loans.Where(p => p.Id == Id).FirstOrDefaultAsync();
            return result;
        }
        public async Task<Loan> UpdateLoanAsync(LoanDTO loanDTO)
        {
            var loan = new Loan
            {
                Id = loanDTO.Id,
                UserId = loanDTO.UserId,
                BookId = loanDTO.BookId,
                LoanDate = loanDTO.LoanDate,
                ReturnDate = loanDTO.ReturnDate
            };
    
            var result = _managerBookDbContext.Loans.Update(loan);
            await _managerBookDbContext.SaveChangesAsync();
            return loan;
        }

        public async Task<string> ReturnLoanAsync(Guid Id) 
        {
            var result = await _managerBookDbContext.Loans.Where(p => p.Id == Id).FirstOrDefaultAsync();
            if (result.ReturnDate >= DateTime.Now)
                return "Its ok";

            else return "Is not ok";
        }    
      }
    }
