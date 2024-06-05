using ManagerBook.Core.Entities;
using ManagerBook.DTO;
using ManagerBook.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ManagerBook.Application.Services
{
    public class LoanServices
    {
        private readonly ManagerBookDbContext _managerBookDbContext;

        public LoanServices(ManagerBookDbContext managerBookDbContext)

        {
            _managerBookDbContext = managerBookDbContext;
        }
        public async Task<OperationResult> AddAsync(LoanDTO loanDTO)
        {
            var retorno = new OperationResult();

            var ruleReturn = loanDTO.LoanDate.AddDays(7);

            loanDTO.ReturnDate = ruleReturn;

            var loan = new Loan
            {
                Id = loanDTO.Id,
                UserId = loanDTO.UserId,
                BookId = loanDTO.BookId,
                LoanDate = loanDTO.LoanDate,
                StoreId = loanDTO.StoreId,
                ReturnDate = new DateTime(loanDTO.ReturnDate.Year, loanDTO.ReturnDate.Month, loanDTO.ReturnDate.Day)
            };

            var result = await _managerBookDbContext.Loans.AddAsync(loan);

            var bookId = Guid.Parse(loanDTO.BookId);
            var stockBook = await _managerBookDbContext.Books.Where(p => p.Id == bookId).FirstOrDefaultAsync();

            if (stockBook == null)
            {
                retorno.Mensagem = "Book not found";
                retorno.Loan = null;
            }

            if (stockBook.Stock <= 0)
            {
                retorno.Mensagem = "There is no stock of this book.";
                retorno.Loan = null;
            }
            else
            {

                stockBook.Stock = stockBook.Stock - 1;
                _managerBookDbContext.Books.Update(stockBook);
                await _managerBookDbContext.SaveChangesAsync();
                retorno.Mensagem = "The loan is done!";
                retorno.Loan = loan;
            }

            return retorno;
        }

        public async Task<List<Loan>> GetAsync()
        {
            var result = await _managerBookDbContext.Loans.ToListAsync();

            return result;
        }

        public async Task<Loan> GetByIdAsync(Guid Id)
        {
            var result = await _managerBookDbContext.Loans.SingleOrDefaultAsync(p => p.Id == Id);

            return result;
        }

        public async Task<Loan> UpdateReturnDateAsync(Guid Id, DateTime updateDate)
        {
            var get = await _managerBookDbContext.Loans.SingleOrDefaultAsync(p => p.Id == Id);

            get.ReturnDate = new DateTime(updateDate.Year, updateDate.Month, updateDate.Day);

            var result = _managerBookDbContext.Loans.Update(get);

            await _managerBookDbContext.SaveChangesAsync();

            return get;
        }

        public async Task<string> ReturnAsync(Guid Id)
        {
            var result = await _managerBookDbContext.Loans.SingleOrDefaultAsync(p => p.Id == Id);

            if (result == null)
            {
                return "Loan not found";
            }
            var dateTime = new DateTime(result.ReturnDate.Year, result.ReturnDate.Month, result.ReturnDate.Day);

            var dateTimeNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            var taxFee = (dateTimeNow - result.ReturnDate).Days * 3;

            var bookId = Guid.Parse(result.BookId);

            var stockBook = await _managerBookDbContext.Books.Where(p => p.Id == bookId).FirstOrDefaultAsync();


            stockBook.Stock = stockBook.Stock + 1;

            _managerBookDbContext.Books.Update(stockBook);

            _managerBookDbContext.Loans.Remove(result);

            await _managerBookDbContext.SaveChangesAsync();

            if (dateTimeNow <= result.ReturnDate) 
            {
                return "Return ok, no fees!";
            }
            else 
            {
                return "Late returns, fee of 3€ per day." + Environment.NewLine + "Your fee is " + taxFee + "€";
            }      
        }
    }
}