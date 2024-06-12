using ManagerBook.Core.Entities;
using ManagerBook.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManagerBook.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ManagerBookDbContext _dbContext;
        public LoanRepository(ManagerBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Loan>> GetAll()
        {
            return await _dbContext.Loans.ToListAsync();
        }

        public async Task<Loan> GetByIdAsync(Guid Id) 
        {
            return await _dbContext.Loans.SingleOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<Loan> UpdateReturnDateAsync(Loan loan, DateTime updateDate)
        {
            loan.ReturnDate = updateDate;

            _dbContext.Loans.Update(loan);

            return loan;
        }

        public async Task AddAsync(Loan item) 
        {
            await _dbContext.Loans.AddAsync(item);
        }

        public async Task Remove(Loan item) 
        {
            _dbContext.Loans.Remove(item);
        }

     }
}
