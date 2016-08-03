using DataAccess.Model;
using InquilinxsUnidxs.Exceptions;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Security;

namespace InquilinxsUnidxs.Services.Authentication
{
    public class AuthenticationService : DataAccess.Service.AuthenticationService
    {
        private const string _authUsernameFailure = "Username does not exist.";
        private const string _authPasswordFailure = "Incorrect password.";

        private const string _registerUsernameFailure = "Username must not be empty.";
        private const string _registerPasswordFailure = "Password must not be empty.";
        private const string _registerPasswordMatchFailure = "Password confirmation failed. Please re-enter your password.";
        private const string _registerEmailFailure = "Invalid Email address.";

        public void Authenticate(string username, string password)
        {
            var user = base.GetUser(username);

            if (user == null)
                throw new InquilinxsException(message: _authUsernameFailure);

            if (!ValidatePassword(user, password))
                throw new InquilinxsException(message: _authPasswordFailure);

            GenerateAuthTicket(user);
        }

        public void LogOut()
        {
            FormsAuthentication.SignOut();
        }

        public new User GetUser(string username)
        {
            return base.GetUser(username);
        }

        public void GenerateAuthTicket(User user)
        {
            var persistent = true;
            var userData = JsonConvert.SerializeObject(new { ID = user.ID, UserName = user.Username });
            var authTicket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now, DateTime.Now.AddYears(1), persistent, userData);
            var cookie = FormsAuthentication.GetAuthCookie(user.Username, persistent);
            var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            cookie.Value = encryptedTicket;
            HttpContext.Current.Response.SetCookie(cookie);
        }

        public new void Register(string username, string password, string confirmPassword, string email)
        {
            if (String.IsNullOrWhiteSpace(username))
                throw new InquilinxsException(message: _registerUsernameFailure);

            if (String.IsNullOrWhiteSpace(password))
                throw new InquilinxsException(message: _registerPasswordFailure);

            if (password != confirmPassword)
                throw new InquilinxsException(message: _registerPasswordMatchFailure);

            // TODO: implement Email address regex
            //if (email is invalid)
            //    throw new InquilinxsException(message: _registerEmailFailure);

            base.Register(username, password, email);
        }
    }
}