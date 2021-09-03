using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserColorPreferences.API.Domain;

namespace UserColorPreferences.API.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasIndex(p => p.Id, "IDX_Users_Id");

            builder.Property(p => p.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasColumnName("LastName")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(p => p.Age)
                .HasColumnName("Age")
                .HasColumnType("tinyint")
                .IsRequired();

            builder.Property(p => p.FavoriteColor)
                .HasColumnName("FavoriteColor")
                .HasColumnType("varchar(255)")
                .IsRequired();
        }
    }
}