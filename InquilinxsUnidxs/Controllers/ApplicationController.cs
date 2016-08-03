using DataAccess.Model;
using InquilinxsUnidxs.Services.Authentication;
using System.Web.Mvc;
using System.Web.Routing;

namespace InquilinxsUnidxs.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        private const string _status = "422 Unprocessable Entity";
        private const int _statusCode = 422;
        private const string _statusDescription = "Entity validation failed. See errors for details.";

        private AuthenticationService _authenticationService;

        public User CurrentUser;

        protected override void Initialize(RequestContext requestContext)
        {
            _authenticationService = new AuthenticationService();

            // what if the user gets authenticated and stays logged in, but their user record no longer exists in the db?
            // this will be null even though there's a cookie that says the user is authenticated
            // probably need to force the signout action and redirect to signin page
            CurrentUser = _authenticationService.GetUser(requestContext.HttpContext.User.Identity.Name);
            base.Initialize(requestContext);
        }

        protected void SetUnprocessableEntityResponse()
        {
            this.Response.Status = _status;
            this.Response.StatusCode = _statusCode;
            this.Response.StatusDescription = _statusDescription;
        }  
    }
}