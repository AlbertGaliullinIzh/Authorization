using Application.Interfaces;
using Domain.Interfaces;

namespace Authorization.Application.Services
{
    public class HandlerUpdateEmail: IHandlerUpdateEmail
    {
        private IUserDomainActions _userDomainActions;

        public HandlerUpdateEmail(IUserDomainActions userDomainActions)
        {
            _userDomainActions = userDomainActions;
        }

        public async Task UpdateEmailAsync(Guid userId, string newEmail)
        {
            await _userDomainActions.UpdateEmailAsync(userId, newEmail);
        }
    }
}
