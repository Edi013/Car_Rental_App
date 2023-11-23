using CarApp.Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarApp.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureUser(modelBuilder);
            ConfigureCar(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);

            modelBuilder.Entity<User>().Property(x => x.UserName).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.UserName).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(x => x.Password).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Password).HasMaxLength(100);
        }

        private void ConfigureCar(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasKey(x => x.Id);

            modelBuilder.Entity<Car>().Property(x => x.Brand).IsRequired();
            modelBuilder.Entity<Car>().Property(x => x.Model).IsRequired();
            modelBuilder.Entity<Car>().Property(x => x.Model).HasMaxLength(50);
            modelBuilder.Entity<Car>().Property(x => x.Type).IsRequired();
            modelBuilder.Entity<Car>().Property(x => x.Price).IsRequired();
        }
    }
}
