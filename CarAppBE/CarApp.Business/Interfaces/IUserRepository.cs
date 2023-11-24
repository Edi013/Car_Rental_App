using CarApp.Business.Entities;

namespace CarApp.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<bool> Login(User user);
        Task<bool> Logout();
        Task Register(User user);
        Task<IEnumerable<User>> GetAll();
    }
}