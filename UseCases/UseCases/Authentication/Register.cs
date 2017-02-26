using Services;
using Services.Exceptions;
using System.Text.RegularExpressions;

namespace UseCases
{
    public class Register : IRegister
    {
        const string registerUsernameFailure = "Username must not be empty.";
        const string registerPasswordFailure = "Password must not be empty.";
        const string registerPasswordMatchFailure = "Password confirmation failed. Please re-enter your password.";
        const string registerEmailFailure = "Invalid Email address.";

        public readonly IAuthenticationService authenticationService;

        public Register(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        public void Execute(string username, string password, string confirmPassword, string email)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new InquilinxsException(message: registerUsernameFailure);

            if (string.IsNullOrWhiteSpace(password))
                throw new InquilinxsException(message: registerPasswordFailure);

            if (password != confirmPassword)
                throw new InquilinxsException(message: registerPasswordMatchFailure);

            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!regex.Match(email).Success)
                throw new InquilinxsException(message: registerEmailFailure);
 
            authenticationService.Register(username, password, email);
        }
    }
}