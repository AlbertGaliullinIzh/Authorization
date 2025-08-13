namespace Authorization.Infrastructure.DataDB.Models
{
    public class AuthDataEntity
    {
        public Guid Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserEntity? User { get; set; }
    }

}

