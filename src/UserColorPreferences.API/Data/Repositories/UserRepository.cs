using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserColorPreferences.API.Data.Repositories.Interfaces;
using UserColorPreferences.API.Domain;

namespace UserColorPreferences.API.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserColorPreferencesContext _dbContext;

        public UserRepository(UserColorPreferencesContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<bool> Delete(User user)
        {
            var localEntry = _dbContext.Set<User>().Local.FirstOrDefault(l => l.Id.Equals(user.Id));

            if (localEntry is not null)
                _dbContext.Entry(localEntry).State = EntityState.Detached;


            _dbContext.Entry(user).State = EntityState.Deleted;
            _dbContext.Users.Remove(user);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<User> Get(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<User>> List()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> Insert(User user)
        {
            _dbContext.Users.Add(user);

            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> Update(User user)
        {
            var localEntry = _dbContext.Set<User>().Local.FirstOrDefault(l => l.Id.Equals(user.Id));

            if (localEntry is not null)
                _dbContext.Entry(localEntry).State = EntityState.Detached;


            _dbContext.Entry(user).State = EntityState.Modified;

            _dbContext.Users.Update(user);


            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}
