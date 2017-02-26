using Newtonsoft.Json;
using Services;
using System;
using System.Web;
using System.Web.Security;

namespace UseCases
{
    public class Authenticate : IAuthenticate
    {
        readonly IAuthenticationService authenticationService;

        public Authenticate(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        public void Execute(string username, string password)
        {   
            var user = authenticationService.Authenticate(username, password);
            GenerateAuthTicket(user.ID, user.UserName);
        }

        void GenerateAuthTicket(int userID, string username)
        {
            var persistent = true;
            var userData = JsonConvert.SerializeObject(new { ID = userID, UserName = username });
            var authTicket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddYears(1), persistent, userData);
            var cookie = FormsAuthentication.GetAuthCookie(username, persistent);
            var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            cookie.Value = encryptedTicket;
            HttpContext.Current.Response.SetCookie(cookie);
        }
    }
}