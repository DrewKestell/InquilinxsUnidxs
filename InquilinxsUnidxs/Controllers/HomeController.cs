using System.Web.Mvc;

namespace InquilinxsUnidxs.Controllers
{
    public class HomeController : ApplicationController
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return this.View();
        }
    }
}