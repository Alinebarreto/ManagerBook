using ManagerBook.Infrastructure;
using ManagerBook.Core.Entities;
using Microsoft.EntityFrameworkCore;
using ManagerBook.DTO;

namespace ManagerBook.Application.Services
{
    public class UserServices
    {
        private readonly ManagerBookDbContext _managerBookDbContext;

        public UserServices(ManagerBookDbContext managerBookDbContext)

        {
            _managerBookDbContext = managerBookDbContext;
        }

        public async Task<List<User>> GetAsync()
        {
            var result = await _managerBookDbContext.Users.ToListAsync();

            return result;
        }
        public async Task<User> GetByIdAsync(Guid Id)
        {
            var result = await _managerBookDbContext.Users.SingleOrDefaultAsync(p => p.Id == Id);

            return result;
        }

        public async Task<User> AddAsync(UserDTO userDTO)
        {
            var user = new User
            {
                Id = userDTO.Id,
                Name = userDTO.Name,
                Email = userDTO.Email,          
            };

            var result = await _managerBookDbContext.Users.AddAsync(user);

            await _managerBookDbContext.SaveChangesAsync();

            return user;
        }

    }
}
