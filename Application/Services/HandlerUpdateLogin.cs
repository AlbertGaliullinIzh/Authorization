using Application.Interfaces;
using Domain.Interfaces;

namespace Authorization.Application.Services
{
    public class HandlerUpdateLogin: IHandlerUpdateLogin
    {
        private IUserDomainActions _userDomainActions;

        public HandlerUpdateLogin(IUserDomainActions userDomainActions)
        {
            _userDomainActions = userDomainActions;
        }

        public async Task UpdateLoginAsync(Guid userId, string newLogin)
        {
            await _userDomainActions.UpdateLoginAsync(userId, newLogin);
        }
    }
}
