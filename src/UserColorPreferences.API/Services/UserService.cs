using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserColorPreferences.API.Data.Repositories.Interfaces;
using UserColorPreferences.API.Domain;
using UserColorPreferences.API.Models;
using UserColorPreferences.API.Services.Interfaces;

namespace UserColorPreferences.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<bool> Delete(int id)
        {
            var user = await _userRepository.Get(id);

            if (user is null)
                return default;


            return await _userRepository.Delete(user);
        }

        public async Task<IEnumerable<UserDTO>> List()
        {
            IEnumerable<User> users = await _userRepository.List();

            return users.Select(user => new UserDTO(user));
        }

        public async Task<UserDTO> Get(int id)
        {
            User user = await _userRepository.Get(id);

            return new UserDTO(user);
        }

        public async Task<UserDTO> Insert(UserDTO userDTO)
        {
            var user = await _userRepository.Insert(userDTO.ToModel());

            return new UserDTO(user);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var user = await _userRepository.Get(userDTO.Id.GetValueOrDefault());

            if (user is null)
                return default;


            user = await _userRepository.Update(userDTO.ToModel());

            return new UserDTO(user);
        }
    }
}
