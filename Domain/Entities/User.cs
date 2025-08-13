namespace Authorization.Domain.Entities
{
    public record User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string? Password { get; set; }
        public List<string> Roles { get; set; } = [];
    }
}
