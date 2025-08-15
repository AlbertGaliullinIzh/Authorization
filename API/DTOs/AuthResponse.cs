using API.DTOs;

namespace Authorization.Application.DTOs
{
    public record AuthResponse
    {
        public string Status { get; set; }
        public List<string> Errors { get; set; }
        public UserAPI User { get; set; }
    }
}
