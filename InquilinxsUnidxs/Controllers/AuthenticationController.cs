using Services.Exceptions;
using System.Web.Mvc;
using System.Web.Security;
using UseCases;

namespace InquilinxsUnidxs.Controllers
{
    [Authorize]
    public class AuthenticationController : Controller
    {
        const string registrationSuccessful = "Registration was successful. You may now log in.";

        readonly IAuthenticationUseCases useCases;

        public AuthenticationController(IAuthenticationUseCases useCases)
        {
            this.useCases = useCases; 
        }

        [AllowAnonymous, HttpGet]
        public ActionResult LogIn()
        {
            ViewBag.Error = TempData["Error"];
            ViewBag.Success = TempData["Success"];
            return View();
        }

        [AllowAnonymous, HttpPost]
        public ActionResult Authenticate(string username, string password)
        {
            try
            {
                useCases.Authenticate.Execute(username, password);
            }
            catch (InquilinxsException e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction("LogIn");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }

        [AllowAnonymous, HttpGet]
        public ActionResult NewUser()
        {
            ViewBag.Error = TempData["Error"];
            return View();
        }

        [AllowAnonymous, HttpPost]
        public ActionResult Register(string username, string password, string confirmPassword, string email)
        {
            try
            {
                useCases.Register.Execute(username, password, confirmPassword, email);
            }
            catch(InquilinxsException e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction("NewUser");
            }
            TempData["Success"] = registrationSuccessful;
            return RedirectToAction("LogIn");
        }
    }
}