
namespace Authorization.Infrastructure.Interfaces
{
    public interface IUserActionsFromDB
    {
        public Task Create(string name, string email, string login, string password, string[] roles );
        public Task<bool> CheckDataAuth(string login, string password);
        public Task UpdateName(Guid userId, string value);
        public Task UpdateEmail(Guid userId, string value);

    }
}
