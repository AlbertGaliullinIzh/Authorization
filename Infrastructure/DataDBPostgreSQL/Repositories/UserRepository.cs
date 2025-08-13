using Authorization.Infrastructure.DataDB.Models;
using Authorization.Infrastructure.Interfaces;
using System.Text;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace Authorization.Infrastructure.DataDB.Repositories
{
    public class UserRepository : IUserActionsFromDB, IAuthDataActions
    {
        private readonly AuthorizationDbContext _learningDBContext;
        public UserRepository(AuthorizationDbContext learningDBContext)
        {
            _learningDBContext = learningDBContext;
        }
        string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }


        public async Task<bool> CheckDataAuth(string login, string password)
        {
            var userAuth = await _learningDBContext.AuthData
                .FirstOrDefaultAsync(x => x.Login == login);

            if (userAuth == null)
                return false;

            string passwordHash = HashPassword(password);

            return userAuth.Password == passwordHash;
        }

        public async Task Create(string name, string email, string login, string password, string[] roles)
        {
            var newUser = new UserEntity()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                AuthData = new AuthDataEntity()
                {
                    Login = login,
                    Password = HashPassword(password)
                }
            };

            _learningDBContext.Add(newUser);
            await _learningDBContext.SaveChangesAsync();
        }
        public async Task UpdateName(Guid userId, string value) 
        {
            await _learningDBContext.Users
                .Where(x=>x.Id == userId)
                .ExecuteUpdateAsync(u => u.SetProperty(v => v.Name, value));
        }

        public async Task UpdateEmail(Guid userId, string value)
        {
            await _learningDBContext.Users
                .Where(x => x.Id == userId)
                .ExecuteUpdateAsync(u => u.SetProperty(v => v.Email, value));
        }

        public async Task UpdatePassword(Guid userId, string value)
        {
            await _learningDBContext.Users
                .Where(x => x.Id == userId)
                .ExecuteUpdateAsync(u => u.SetProperty(v => v.AuthData.Password, HashPassword(value)));
        }

        public async Task UpdateLogin(Guid userId, string value)
        {
            await _learningDBContext.Users
                .Where(x => x.Id == userId)
                .ExecuteUpdateAsync(u => u.SetProperty(v => v.AuthData.Login, value));
        }

    }
}
