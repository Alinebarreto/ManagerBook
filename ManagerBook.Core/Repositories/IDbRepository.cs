namespace ManagerBook.Core.Repositories
{
    public interface IDbRepository
    {
        Task SaveChangesAsync();
        IStoreRepository StoreRepository { get; }
        IUserRepository UserRepository { get; }
        IBookRepository BookRepository { get; }
        ILoanRepository LoanRepository { get; }
    }
}
