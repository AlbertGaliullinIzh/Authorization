namespace API.DTOs
{
    public record RegistrationModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
