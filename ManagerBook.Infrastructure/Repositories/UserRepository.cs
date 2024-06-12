using ManagerBook.Core.Entities;
using ManagerBook.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBook.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ManagerBookDbContext _dbcontext;
        public UserRepository(ManagerBookDbContext dbContext)
        {
            _dbcontext = dbContext;            
        }

        public async Task<List<User>> GetAll() 
        {
            return await _dbcontext.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid Id) 
        {
            return await _dbcontext.Users.SingleOrDefaultAsync(p => p.Id == Id);

        }

        public async Task AddAsync(User item) 
        {
            await _dbcontext.Users.AddAsync(item);
        }
    }
}

