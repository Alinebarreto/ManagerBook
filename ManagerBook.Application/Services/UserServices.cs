using ManagerBook.Core.Entities;
using ManagerBook.Core.Repositories;
using ManagerBook.DTO;

namespace ManagerBook.Application.Services
{
    public class UserServices
    {
        private readonly IDbRepository _dbRepository;
      

        public UserServices(IDbRepository dbRepository)

        {
            _dbRepository = dbRepository;          
        }

        public async Task<List<User>> GetAll()
        {
            var result = await _dbRepository.UserRepository.GetAll();

            return result;
        }
        public async Task<User> GetByIdAsync(Guid Id)
        {
            var result = await _dbRepository.UserRepository.GetByIdAsync(Id);

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

            await _dbRepository.UserRepository.AddAsync(user);

            await _dbRepository.SaveChangesAsync();

            return user;
        }

    }
}
