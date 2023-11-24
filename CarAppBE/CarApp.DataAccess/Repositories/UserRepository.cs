using CarApp.Business.Entities;
using CarApp.Business.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarApp.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<bool> Login(User user)
        {
            var operationResult = this.context.Users
                .FirstOrDefaultAsync(u => u.UserName == user.UserName && u.Password == user.Password);

            return operationResult.Result == null ? false : true;
        }

        public async Task<bool> Logout()
        {
            return false;
        }

        public async Task Register(User user)
        {
            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();
        }

    }
}
