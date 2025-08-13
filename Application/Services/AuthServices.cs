using Authorization.Application.DTOs;
using Authorization.Infrastructure.Interfaces;
using System.Text.RegularExpressions;

namespace Authorization.Application.Services
{
    public class AuthServices
    {
        private IUserActionsFromDB _userActionsFromDB;

        public AuthServices(IUserActionsFromDB userActionsFromDB)
        {
            _userActionsFromDB = userActionsFromDB;
        }

        public async Task<AuthResponse> Registration(string login, string password, string name, string email, string[] roles)
        {
            if (string.IsNullOrWhiteSpace(login))
                throw new ArgumentException("Login cannot be empty", nameof(login));
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be empty", nameof(password));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty", nameof(email));

            if (!IsValidEmail(email))
                throw new ArgumentException("Email format is invalid", nameof(email));

            if (!IsValidPassword(password))
                throw new ArgumentException("Password must be at least 8 characters long, contain uppercase, lowercase and a digit", nameof(password));

            roles ??= ["student"];


            try 
            {
                _userActionsFromDB.Create(name, email, login, password, roles);
            }
            catch
            { }


            var response = new AuthResponse
            {
                status = "Выполнено"
            };

            return await Task.FromResult(response);
        }
        private bool IsValidEmail(string email)
        {
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);
            return regex.IsMatch(email);
        }
        private bool IsValidPassword(string password)
        {
            if (password.Length < 8) return false;
            if (!Regex.IsMatch(password, @"[A-Z]")) return false;
            if (!Regex.IsMatch(password, @"[a-z]")) return false;
            if (!Regex.IsMatch(password, @"\d")) return false;
            return true;
        }
    }
}
