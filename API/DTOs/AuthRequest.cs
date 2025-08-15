namespace Authorization.Application.DTOs
{
    public record AuthRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
