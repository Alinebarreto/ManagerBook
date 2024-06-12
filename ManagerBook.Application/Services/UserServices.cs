using ManagerBook.Core.Entities;
using ManagerBook.Core.Repositories;
using ManagerBook.DTO;

namespace ManagerBook.Application.Services
{
    public class UserServices
    {
        private readonly IDbRepository _dbRepository;
        private readonly IUserRepository _userRepository;        

        public UserServices(IDbRepository dbRepository, IUserRepository userRepository)

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
