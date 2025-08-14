using Authorization.Domain.Entities;

namespace Authorization.Domain.Interfaces
{
    public interface IUserDomainActions
    {
        Task<UserDomain> CreateAsync(string login, string password, string name, string email, string[] roles);
        Task<UserDomain> LoginAsync(string login, string password);
        Task UpdateNameAsync(Guid userId, string newName);
        Task UpdateEmailAsync(Guid userId, string newEmail);
        Task UpdatePasswordAsync(Guid userId, string oldPassword, string newPassword);
        Task UpdateLoginAsync(Guid userId, string newLogin);
        Task<bool> IsLoginFree(string login);
    }
}
