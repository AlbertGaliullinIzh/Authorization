namespace Authorization.Application.DTOs
{
    public class AuthResponse
    {
        public string status { get; set; }
        public List<string> Errors { get; set; }
    }
}
