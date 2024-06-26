﻿using ManagerBook.Core.Entities;
using ManagerBook.Core.Repositories;
using ManagerBook.DTO;

namespace ManagerBook.Application.Services
{
    public class LoanServices
    {
        private readonly IDbRepository _dbRepository;

        public LoanServices(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
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

            await _dbRepository.LoanRepository.AddAsync(loan);

            var bookId = Guid.Parse(loanDTO.BookId);
            var stockBook = await _dbRepository.BookRepository.GetByIdAsync(bookId);

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
                await _dbRepository.BookRepository.UpdateAsync(stockBook);

                await _dbRepository.SaveChangesAsync();

                retorno.Mensagem = "The loan is done!";
                retorno.Loan = loan;
            }

            return retorno;
        }

        public async Task<List<Loan>> GetAll()
        {
            var result = await _dbRepository.LoanRepository.GetAll();

            return result;
        }

        public async Task<Loan> GetByIdAsync(Guid Id)
        {
            var result = await _dbRepository.LoanRepository.GetByIdAsync(Id);

            return result;
        }

        public async Task<Loan> UpdateReturnDateAsync(Guid Id, DateTime updateDate)
        {
            var loan = await _dbRepository.LoanRepository.GetByIdAsync(Id);
            updateDate = new DateTime(updateDate.Year, updateDate.Month, updateDate.Day);

            if (loan != null)
            {
                loan = await _dbRepository.LoanRepository.UpdateReturnDateAsync(loan, updateDate);
            }

            await _dbRepository.SaveChangesAsync();

            return loan;
        }

        public async Task<string> ReturnId(Guid Id)
        {
            var result = await _dbRepository.LoanRepository.GetByIdAsync(Id);

            if (result == null)
            {
                return "Loan not found";
            }
            var dateTime = new DateTime(result.ReturnDate.Year, result.ReturnDate.Month, result.ReturnDate.Day);

            var dateTimeNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            var taxFee = (dateTimeNow - result.ReturnDate).Days * 3;

            var bookId = Guid.Parse(result.BookId);

            var stockBook = await _dbRepository.BookRepository.GetByIdAsync(bookId);


            stockBook.Stock = stockBook.Stock + 1;

            await _dbRepository.BookRepository.UpdateAsync(stockBook);

            await _dbRepository.LoanRepository.Remove(result);


            await _dbRepository.SaveChangesAsync();

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