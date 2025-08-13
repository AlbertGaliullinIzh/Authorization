using Authorization.Domain.Entities;

namespace Authorization.Domain.Interfaces
{
    public interface IUserActions
    {
        Task<User> CreateAsync(string login, string password, string name = "", string email = "", string[] roles = null);
        Task<User> GetByIdAsync(int id);
        Task<User> GetByEmailAsync(string email);
        Task<List<User>> GetByUsernameAsync(string username);
        Task<User> GetByLoginAsync(string login);
    }
}
