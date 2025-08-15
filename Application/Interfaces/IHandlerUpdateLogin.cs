namespace Application.Interfaces
{
    public interface IHandlerUpdateLogin
    {
        Task UpdateLoginAsync(Guid userId, string newLogin);
    }
}
