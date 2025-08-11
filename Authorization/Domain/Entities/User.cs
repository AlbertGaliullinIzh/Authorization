namespace Authorization.Domain.Entities
{
    public record User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }
}
