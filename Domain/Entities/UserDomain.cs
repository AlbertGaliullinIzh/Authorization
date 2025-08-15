using Domain.Entities;

namespace Authorization.Domain.Entities
{
    public record UserDomain
    {
        public Guid Id { get; set; }
        public required EmailDomain Email { get; set; }
        public required NameDomain Name { get; set; }
        public required LoginDomain Login { get; set; }
        public required PasswordDomain Password { get; set; }
        public required RolesDomain Roles { get; set; }
    }
}
