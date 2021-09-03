using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using UserColorPreferences.API.Data.Mappings;
using UserColorPreferences.API.Domain;

namespace UserColorPreferences.API.Data
{
    public class UserColorPreferencesContext : DbContext
    {
        public UserColorPreferencesContext(DbContextOptions<UserColorPreferencesContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<User>())
            {
                if (entry.State == EntityState.Added)
                    entry.Entity.Id = default;

                if (entry.State == EntityState.Modified || entry.State == EntityState.Added)
                    entry.Entity.FavoriteColor = entry.Entity.FavoriteColor.ToLower();
            }

            return await base.SaveChangesAsync();
        }
    }
}
