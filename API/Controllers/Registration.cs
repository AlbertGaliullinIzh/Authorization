using Authorization.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class Registration : Controller
    {
        IUserDomainActions _userDomainActions;
        public Registration(IUserDomainActions userDomainActions)
        {
            _userDomainActions = userDomainActions;
        }

        [HttpPost("RegistrationUser")]
        public async Task<IActionResult> RegistrationUser(string login, string password, string name = "", string email = "", string[] roles = null)
        {
            await _userDomainActions.CreateAsync(login = login, password = password, name = name, email = email, roles = roles);
        }
        [HttpPost("UpdateName")]
        public async Task<IActionResult> UpdateName([FromBody] Guid userId, [FromBody] string newName)
        {

        }
        [HttpPost("UpdateLogin")]
        public async Task<IActionResult> UpdateLogin([FromBody] Guid userId, [FromBody] string newLogin)
        {

        }
        [HttpPost("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody] Guid userId, [FromBody] string oldPassword, [FromBody] string newPassword)
        {

        }
        [HttpPost("UpdateEmail")]
        public async Task<IActionResult> UpdateEmail([FromBody] Guid userId, [FromBody] string newEmail)
        {

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] string login, [FromBody] string password)
        {

        }
    }
}
