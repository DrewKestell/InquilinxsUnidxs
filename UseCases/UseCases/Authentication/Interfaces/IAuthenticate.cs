namespace UseCases
{
    public interface IAuthenticate
    {
        void Execute(string username, string password);
    }
}