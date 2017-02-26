using Services.DTO;

namespace Services
{
    public interface IAuthenticationService
    {
        void Register(string username, string password, string email);
        UserDTO Authenticate(string username, string passwordInput);
    }
}