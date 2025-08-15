namespace Application.Interfaces
{
    public interface IHandlerUpdateName
    {
        Task UpdateNameAsync(Guid userId, string newName);
    }
}
