using ManagerBook.Core.Entities;

namespace ManagerBook.Core.Repositories
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAll();
        Task<Loan> GetByIdAsync(Guid Id);
        Task<Loan> UpdateReturnDateAsync(Loan loan, DateTime updateDate);
        Task Remove(Loan item);
        Task AddAsync(Loan item);
    }
}
