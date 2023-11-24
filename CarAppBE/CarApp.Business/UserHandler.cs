using CarApp.Business.DTO;
using CarApp.Business.Entities;
using CarApp.DataAccess.Repositories;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

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
                Password = GetHash(dto.Password)
            };
        }
        private string GetHash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    builder.Append(data[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
