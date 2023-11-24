using CarApp.Business.DTO;
using CarApp.Business.Entities;
using CarApp.DataAccess.Repositories;

namespace CarApp.Business
{
    public class UserHandler
    {
        private IUserRepository repository;

        public UserHandler(IUserRepository repository)
        {
            this.repository = repository;
        }
        public async Task<bool> Login(UserDto dto)
        {
            var user = UserDtoToUser(dto);

            return await repository.Login(user);
        }

        public async Task<bool> Logout()
        {
            return await repository.Logout();
        }

        public async Task Register(UserDto dto)
        {
            var user = UserDtoToUser(dto);

            await repository.Register(user);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await repository.GetAll();
        }
        private User UserDtoToUser(UserDto dto)
        {
           
            return new User()
            {
                UserName = dto.UserName,
                Password = SHA256Hash.GetHash(dto.Password)
            };
        }
    }
}
