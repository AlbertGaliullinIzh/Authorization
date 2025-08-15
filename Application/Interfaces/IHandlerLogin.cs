namespace Application.Interfaces
{
    public interface IHandlerLogin
    {
        Task LoginAsync(string login, string password);
    }
}
