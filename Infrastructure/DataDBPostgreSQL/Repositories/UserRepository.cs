using Authorization.Infrastructure.DataDB.Models;
using Microsoft.EntityFrameworkCore;
using Authorization.Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DataDBPostgreSQL.Models;

namespace Authorization.Infrastructure.DataDB.Repositories
{
    public class UserRepository : IUserDomainActions
    {
        private readonly AuthorizationDbContext _learningDBContext;
        public UserRepository(AuthorizationDbContext learningDBContext)
        {
            _learningDBContext = learningDBContext;
        }
        public async Task<bool> CheckDataAuth(string login, string password)
        {
            var userAuth = await _learningDBContext.AuthData
                .FirstOrDefaultAsync(x => x.Login == login);

            if (userAuth == null)
                return false;

            string passwordHash = password;

            return userAuth.Password == passwordHash;
        }

        public async Task<UserDomain> CreateAsync(string login, string password, string name, string email, string role)
        {
            var _role = await _learningDBContext.Roles.FirstOrDefaultAsync(r => r.Name == role);

            if (role == null)
                throw new Exception($"Роль '{role}' не найдена");
            var newUser = new UserEntity()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                AuthData = new AuthDataEntity()
                {
                    Login = login,
                    Password = password
                },
                Role = _role

            };

            _learningDBContext.Add(newUser);
            await _learningDBContext.SaveChangesAsync();
            return UserMapper.ToDomain(newUser);
        }

        public async Task<UserDomain> LoginAsync(string login, string password)
        {
            var account = await _learningDBContext.Users.FirstAsync(x => x.AuthData.Login == login && x.AuthData.Password == password);
            return UserMapper.ToDomain(account);
        }

        public async Task UpdateNameAsync(Guid userId, string newName)
        {
            await _learningDBContext.Users
                .Where(x => x.Id == userId)
                .ExecuteUpdateAsync(u => u.SetProperty(v => v.Name, newName));
        }

        public async Task UpdateEmailAsync(Guid userId, string newEmail)
        {
            await _learningDBContext.Users
                .Where(x => x.Id == userId)
                .ExecuteUpdateAsync(u => u.SetProperty(v => v.Email, newEmail));
        }

        public async Task UpdatePasswordAsync(Guid userId, string oldPassword, string newPassword)
        {
            var passwordOrigin = _learningDBContext.Users.Any(x => x.Id == userId && x.AuthData.Password == oldPassword);
            if (!passwordOrigin)
            {
                throw new Exception("Старый пароль неверный");
            }
            await _learningDBContext.Users
               .Where(x => x.Id == userId)
               .ExecuteUpdateAsync(u => u.SetProperty(v => v.AuthData.Password, newPassword));
        }

        public async Task UpdateLoginAsync(Guid userId, string newLogin)
        {
            await _learningDBContext.Users
                .Where(x => x.Id == userId)
                .ExecuteUpdateAsync(u => u.SetProperty(v => v.AuthData.Login, newLogin));
        }

        public async Task<bool> IsLoginFree(string login)
        {
            return _learningDBContext.Users.Any(x => x.AuthData.Login == login);
        }
    }
}
