using System.Collections.Generic;
using System.Threading.Tasks;
using UserColorPreferences.API.Models;

namespace UserColorPreferences.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> Delete(int id);
        Task<UserDTO> Get(int id);
        Task<IEnumerable<UserDTO>> List();
        Task<UserDTO> Insert(UserDTO userDTO);
        Task<UserDTO> Update(UserDTO userDTO);
    }
}
