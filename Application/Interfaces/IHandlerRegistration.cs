using Authorization.Domain.Entities;

namespace Application.Interfaces
{
    public interface IHandlerRegistration
    {
        Task<UserDomain> RegistrationAsync(string login, string password, string name, string email, string role);
    }
}
