using InquilinxsUnidxs.Exceptions;
using InquilinxsUnidxs.Services.Authentication;
using System.Web.Mvc;
using System.Web.Routing;

namespace InquilinxsUnidxs.Controllers
{
    public class AuthenticationController : ApplicationController
    {
        private AuthenticationService _authenticationService;
        private const string _registrationSuccessful = "Registration was successful. You may now log in.";

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            _authenticationService = new AuthenticationService();
        }

        [AllowAnonymous]
        public ActionResult LogIn()
        {
            ViewBag.Error = TempData["Error"];
            ViewBag.Success = TempData["Success"];
            return this.View();
        }

        [AllowAnonymous]
        public ActionResult Authenticate(string username, string password)
        {
            try
            {
                _authenticationService.Authenticate(username, password);
            }
            catch (InquilinxsException e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction("LogIn");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            _authenticationService.LogOut();
            return RedirectToAction("LogIn");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            ViewBag.Error = TempData["Error"];
            return View();
        }

        [AllowAnonymous, HttpPost]
        public ActionResult Register(string username, string password, string confirmPassword, string email)
        {
            try
            {
                _authenticationService.Register(username, password, confirmPassword, email);
            }
            catch(InquilinxsException e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction("Register");
            }
            TempData["Success"] = _registrationSuccessful;
            return RedirectToAction("LogIn");
        }
    }
}