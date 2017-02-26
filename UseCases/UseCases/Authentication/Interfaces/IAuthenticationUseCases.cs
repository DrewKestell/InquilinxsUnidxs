namespace UseCases
{
    public interface IAuthenticationUseCases
    {
        IAuthenticate Authenticate { get; }
        IRegister Register { get; }
    }
}