using System.Web.Mvc;

namespace InquilinxsUnidxs.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous, HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}