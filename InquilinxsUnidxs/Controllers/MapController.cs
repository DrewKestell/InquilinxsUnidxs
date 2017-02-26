using DataAccess.FormObject;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using UseCases;

namespace InquilinxsUnidxs.Controllers
{
    public class MapController : Controller
    {
        readonly IMapUseCases useCases;

        public MapController(IMapUseCases useCases)
        {
            this.useCases = useCases;
        }

        [HttpGet]
        public ActionResult Show(int? neighborhoodID = null, int? landlordID = null, string filter = null)
        {
            var presenter = useCases.GetMap.Execute(neighborhoodID, landlordID, filter);

            if (Request.IsAjaxRequest())
                return Json(presenter, JsonRequestBehavior.AllowGet);
            else
                return View(presenter);
        }

        [HttpPost]
        public ActionResult UpdateGeolocation(List<MapBuildingFormObject> formObjects)
        {
            useCases.UpdateGeolocation.Execute(formObjects);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}