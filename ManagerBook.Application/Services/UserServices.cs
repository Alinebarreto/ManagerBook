using ManagerBook.Core.Entities;
using ManagerBook.DTO;
using ManagerBook.Infrastructure.Repositories;

namespace ManagerBook.Application.Services
{
    public class UserServices
    {
        private readonly DbRepository _dbRepository;
        private readonly UserRepository _userRepository;        

        public UserServices(DbRepository dbRepository, UserRepository userRepository)

        {
            _dbRepository = dbRepository;
            _userRepository = userRepository;            
        }

        public async Task<List<User>> GetAll()
        {
            var result = await _userRepository.GetAll();

            return result;
        }
        public async Task<User> GetByIdAsync(Guid Id)
        {
            var result = await _userRepository.GetByIdAsync(Id);

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

            await _userRepository.AddAsync(user);

            await _dbRepository.SaveChangesAsync();

            return user;
        }

    }
}
