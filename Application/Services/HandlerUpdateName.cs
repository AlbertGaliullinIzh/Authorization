using Application.Interfaces;
using Domain.Interfaces;

namespace Authorization.Application.Services
{
    public class HandlerUpdateName: IHandlerUpdateName
    {
        private IUserDomainActions _userDomainActions;

        public HandlerUpdateName(IUserDomainActions userDomainActions)
        {
            _userDomainActions = userDomainActions;
        }

        public async Task UpdateNameAsync(Guid userId, string newName)
        {
            await _userDomainActions.UpdateNameAsync(userId, newName);
        }
    }
}
