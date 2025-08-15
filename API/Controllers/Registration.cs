using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using API.DTOs;
namespace API.Controllers
{

    public class Registration : Controller
    {
        IHandlerLogin _handlerLogin;
        IHandlerRegistration _handlerRegistration;
        IHandlerUpdateEmail _handlerUpdateEmail;
        IHandlerUpdateName _handlerUpdateName;
        IHandlerUpdatePassword _handlerUpdatePassword;
        IHandlerUpdateLogin _handlerUpdateLogin;
        public Registration(IHandlerRegistration handlerRegistration, IHandlerUpdateEmail handlerUpdateEmail, IHandlerUpdateName handlerUpdateName, IHandlerUpdatePassword handlerUpdatePassword, IHandlerUpdateLogin handlerUpdateLogin)
        {
            _handlerRegistration = handlerRegistration;
            _handlerUpdateEmail = handlerUpdateEmail;
            _handlerUpdateName = handlerUpdateName;
            _handlerUpdatePassword = handlerUpdatePassword;
            _handlerUpdateLogin = handlerUpdateLogin;
        }

        [HttpPost("RegistrationUser")]
        public async Task<IActionResult> RegistrationUser([FromBody] RegistrationModel registrationModel)
        {
            if (registrationModel.Login == null ||
                registrationModel.Password == null ||
                registrationModel.Name == null ||
                registrationModel.Email == null ||
                registrationModel.Role == null)
                return BadRequest("Данные не заполнены");

            if (string.IsNullOrEmpty(registrationModel.Login) ||
                string.IsNullOrEmpty(registrationModel.Password) ||
                string.IsNullOrEmpty(registrationModel.Name) ||
                string.IsNullOrEmpty(registrationModel.Email) ||
                string.IsNullOrEmpty(registrationModel.Role))
                return BadRequest("Данные не заполнены");

            await _handlerRegistration.RegistrationAsync(registrationModel.Login, registrationModel.Password, registrationModel.Name, registrationModel.Email, registrationModel.Role);
            return Ok();
        }
        [HttpPost("UpdateName")]
        public async Task<IActionResult> UpdateName([FromBody] Guid userId, [FromBody] string newName)
        {
            await _handlerUpdateName.UpdateNameAsync(userId, newName);
            return Ok();
        }
        [HttpPost("UpdateLogin")]
        public async Task<IActionResult> UpdateLogin([FromBody] Guid userId, [FromBody] string newLogin)
        {
            await _handlerUpdateLogin.UpdateLoginAsync(userId, newLogin);
            return Ok();
        }
        [HttpPost("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody] Guid userId, [FromBody] string oldPassword, [FromBody] string newPassword)
        {
            await _handlerUpdatePassword.UpdatePasswordAsync(userId, oldPassword, newPassword);
            return Ok();
        }
        [HttpPost("UpdateEmail")]
        public async Task<IActionResult> UpdateEmail([FromBody] Guid userId, [FromBody] string newEmail)
        {
            _handlerUpdateEmail.UpdateEmailAsync(userId, newEmail);
            return Ok();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] string login, [FromBody] string password)
        {
            await _handlerLogin.LoginAsync(login, password);
            return Ok();
        }
    }
}
