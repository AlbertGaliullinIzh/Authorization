using Domain.Entities;

namespace API.DTOs
{
    public record UserAPI
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public required RolesDomain Roles { get; set; }
    }
}
