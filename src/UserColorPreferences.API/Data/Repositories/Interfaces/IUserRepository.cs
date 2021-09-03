using System.Collections.Generic;
using System.Threading.Tasks;
using UserColorPreferences.API.Domain;

namespace UserColorPreferences.API.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Delete(User user);
        Task<User> Get(int id);
        Task<IEnumerable<User>> List();
        Task<User> Insert(User user);
        Task<User> Update(User user);
    }
}
