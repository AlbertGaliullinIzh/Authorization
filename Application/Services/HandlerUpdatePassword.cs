using Application.Interfaces;
using Domain.Interfaces;

namespace Authorization.Application.Services
{
    public class HandlerUpdatePassword: IHandlerUpdatePassword
    {
        private IUserDomainActions _userDomainActions;
        public HandlerUpdatePassword(IUserDomainActions userDomainActions)
        {
            _userDomainActions = userDomainActions;
        }
        public async Task UpdatePasswordAsync(Guid userId, string oldPassword, string newPassword)
        {
            await _userDomainActions.UpdatePasswordAsync(userId, oldPassword, newPassword);
        }
    }
}
