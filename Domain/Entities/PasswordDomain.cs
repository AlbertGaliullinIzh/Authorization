using System.Security.Cryptography;
using System.Text;

namespace Domain.Entities
{

    public record PasswordDomain
    {
        public string Value { get; }

        private PasswordDomain(string value)
        {
            Value = value;
        }
        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public static PasswordDomain Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Пустой пароль");

            if (value.Length < 8)
                throw new ArgumentException("Пароль должен иметь больше 7 символов");

            if (!HasSpecialChar(value))
                throw new ArgumentException("Пароль должен иметь специальные символы");

            if (!HasUpperChar(value))
                throw new ArgumentException("Пароль должен иметь хотя бы одну заглавную букву");

            if (!HasLowerChar(value))
                throw new ArgumentException("Пароль должен иметь хотя бы одну прописную букву");

            return new PasswordDomain(HashPassword(value));
        }

        private static bool HasSpecialChar(string str) => str.Any(c => !char.IsLetterOrDigit(c));
        private static bool HasUpperChar(string str) => str.Any(c => !char.IsUpper(c));
        private static bool HasLowerChar(string str) => str.Any(c => !char.IsLower(c));

    }
}
