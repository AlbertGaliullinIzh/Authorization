using Application.Interfaces;
using Authorization.Domain.Entities;
using Domain.Interfaces;

namespace Authorization.Application.Services
{
    public class HandlerRegistration: IHandlerRegistration
    {
        private IUserDomainActions _userDomainActions;

        public HandlerRegistration(IUserDomainActions userDomainActions)
        {
            _userDomainActions = userDomainActions;
        }

        public async Task<UserDomain> RegistrationAsync(string login, string password, string name, string email, string role)
        {
            return await _userDomainActions.CreateAsync(login, password, name, email, role);
        }
    }
}
