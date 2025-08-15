namespace Application.Interfaces
{
    public interface IHandlerUpdatePassword
    {
        Task UpdatePasswordAsync(Guid userId, string oldPassword, string newPassword);
    }
}
