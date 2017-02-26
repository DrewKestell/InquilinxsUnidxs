namespace UseCases
{
    public class AuthenticationUseCases : IAuthenticationUseCases
    {
        public IAuthenticate Authenticate { get; }
        public IRegister Register { get; }

        public AuthenticationUseCases(IAuthenticate authenticate, IRegister register)
        {
            Authenticate = authenticate;
            Register = register;
        }
    }
}