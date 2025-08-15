using Application.Interfaces;
using Domain.Interfaces;

namespace Authorization.Application.Services
{
    public class HandlerLogin: IHandlerLogin
    {
        private IUserDomainActions _userDomainActions;

        public HandlerLogin(IUserDomainActions userDomainActions)
        {
            _userDomainActions = userDomainActions;
        }

        public async Task LoginAsync(string login, string password)
        {
            await _userDomainActions.LoginAsync(login, password);
        }
    }
}
