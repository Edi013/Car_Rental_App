using CarApp.Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarApp.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureUser(modelBuilder);
            ConfigureCar(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => {
                entity.HasKey(x => x.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<User>().Property(x => x.UserName).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.UserName).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(x => x.Password).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Password).HasMaxLength(100);
        }

        private void ConfigureCar(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity => {
                entity.HasKey(x => x.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Car>().Property(x => x.Brand).IsRequired();
            modelBuilder.Entity<Car>().Property(x => x.Model).IsRequired();
            modelBuilder.Entity<Car>().Property(x => x.Model).HasMaxLength(50);
            modelBuilder.Entity<Car>().Property(x => x.Type).IsRequired();
            modelBuilder.Entity<Car>().Property(x => x.Price).IsRequired();
        }
    }
}
