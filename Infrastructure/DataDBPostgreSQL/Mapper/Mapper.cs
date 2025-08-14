using Authorization.Domain.Entities;
using Authorization.Infrastructure.DataDB.Models;
using Domain.Entities;
using Infrastructure.DataDBPostgreSQL.Models;

public static class UserMapper
{
    public static UserDomain ToDomain(this UserEntity entity)
        => new UserDomain
        {
            Id = entity.Id,
            Name = NameDomain.Create(entity.Name),
            Email = EmailDomain.Create(entity.Email),
            Login = LoginDomain.Create(entity.AuthData.Login),
            Roles = RolesDomain.Create(entity.Role.Name),
            Password = PasswordDomain.Create(entity.AuthData.Password)
        };

    public static UserEntity ToEntity(this UserDomain domain, RoleEntity role)
    {
        return new UserEntity
        {
            Id = domain.Id,
            Name = domain.Name.Value,
            Email = domain.Email.Value,
            AuthData = new AuthDataEntity
            {
                Login = domain.Login.Value,
                Password = domain.Password.Value
            },
            Role = role
        };
    }
}
