using ManagerBook.Core.Repositories;

namespace ManagerBook.Infrastructure.Repositories
{
    public class DbRepository : IDbRepository
    {
        private readonly ManagerBookDbContext _dbContext;
        private readonly IStoreRepository _storeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ILoanRepository _loanRepository;

        public IStoreRepository StoreRepository => _storeRepository;

        public IUserRepository UserRepository => _userRepository;

        public IBookRepository BookRepository => _bookRepository;

        public ILoanRepository LoanRepository => _loanRepository;

        public DbRepository(ManagerBookDbContext dbContext, 
            IStoreRepository storeRepository, 
            IUserRepository userRepository, 
            IBookRepository bookRepository,
            ILoanRepository loanRepository)
        {
            _dbContext = dbContext;
            _storeRepository = storeRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _loanRepository = loanRepository;
        }
        public async Task SaveChangesAsync()
        {
            _dbContext.SaveChangesAsync();
        }
    }
}
