using DataAccess.FormObject;
using InquilinxsUnidxs.Services;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;
using Newtonsoft.Json;

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

        public ActionResult Show(int? neighborhoodID = null, int? landlordID = null, string filter = null)
        {
            var presenter = _mapService.GetMapPresenter(neighborhoodID, landlordID, filter);

            if (Request.IsAjaxRequest())
                return this.Content(JsonConvert.SerializeObject(presenter));
            else
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