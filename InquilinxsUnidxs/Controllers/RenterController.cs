using DataAccess.FormObjects;
using InquilinxsUnidxs.Services.Renter;
using Newtonsoft.Json;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;

namespace InquilinxsUnidxs.Controllers
{
    public class RenterController : Controller
    {
        private RenterService _renterService;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            _renterService = new RenterService();
        }

        public ActionResult Index()
        {
            var presenters = _renterService.GetRenterPresenters();
            return this.View(presenters);
        }

        public ActionResult New()
        {
            var presenter = _renterService.GetNewRenterPresenter();
            return this.View(presenter);
        }
        

        public ActionResult Detail(int renterID)
        {
            var presenter = _renterService.GetRenterPresenter(renterID);
            return this.View(presenter);
        }

        public ActionResult Edit(int renterID)
        {
            var presenter = _renterService.GetRenterPresenter(renterID);
            return this.View(presenter);
        }

        [HttpPost]
        public ContentResult Create(RenterFormObject formObject)
        {
            _renterService.Create(formObject);
            return Content(JsonConvert.SerializeObject(new HttpStatusCodeResult(HttpStatusCode.OK)));
        }

        [HttpPost]
        public ContentResult Update(RenterFormObject formObject)
        {
            _renterService.Update(formObject);
            return Content(JsonConvert.SerializeObject(new HttpStatusCodeResult(HttpStatusCode.OK)));
        }
        
        [HttpDelete]
        public ActionResult Delete(int renterID)
        {
            _renterService.Delete(renterID);
            return RedirectToAction("Index");
        }
    }
}