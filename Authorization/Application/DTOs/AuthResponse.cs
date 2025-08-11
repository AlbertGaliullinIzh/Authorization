using Authorization.Domain.Entities;

namespace Authorization.Application.DTOs
{
    public record AuthResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int ExpiresIn { get; set; }
        public User User { get; set; }
    }
}
