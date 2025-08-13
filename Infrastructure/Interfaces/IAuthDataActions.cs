namespace Authorization.Infrastructure.Interfaces
{
    public interface IAuthDataActions
    {
        public Task UpdatePassword(Guid userId, string value);
        public Task UpdateLogin(Guid userId, string value);
    }
}
