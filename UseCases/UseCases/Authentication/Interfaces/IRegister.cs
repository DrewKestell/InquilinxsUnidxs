namespace UseCases
{
    public interface IRegister
    {
        void Execute(string username, string password, string confirmPassword, string email);
    }
}