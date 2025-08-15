namespace Application.Interfaces
{
    public interface IHandlerUpdateEmail
    {
        Task UpdateEmailAsync(Guid userId, string newEmail);
    }
}
