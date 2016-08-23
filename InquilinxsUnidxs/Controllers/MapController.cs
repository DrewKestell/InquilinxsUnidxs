using DataAccess.FormObject;
using InquilinxsUnidxs.Services;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;

namespace InquilinxsUnidxs.Controllers
{
    public class MapController : ApplicationController
    {
        private MapService _mapService;

        protected override void Initialize(RequestContext requestContext)
        {
            _mapService = new MapService();
            base.Initialize(requestContext);
        }

        public ActionResult Show()
        {
            var presenter = _mapService.GetMapPresenter();
            return this.View(presenter);
        }

        [HttpPost]
        public ActionResult UpdateGeolocation(List<MapBuildingFormObject> formObjects)
        {
            _mapService.UpdateGeolocation(formObjects);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}