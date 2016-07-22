using DataAccess.FormObjects;
using InquilinxsUnidxs.Presenters;
using InquilinxsUnidxs.Services.Renter;
using Newtonsoft.Json;
using System.Data.Entity.Validation;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;

namespace InquilinxsUnidxs.Controllers
{
    public class RenterController : ApplicationController
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
            try
            {
                _renterService.Create(formObject);
                return this.Content(JsonConvert.SerializeObject("/Renter/Index"));
            }
            catch (DbEntityValidationException ex)
            {
                this.SetUnprocessableEntityResponse();
                var presenter = new EntityValidationResultPresenter(ex);
                return this.Content(JsonConvert.SerializeObject(presenter));
            }
        }

        [HttpPost]
        public ContentResult Update(RenterFormObject formObject)
        {
            try
            {
                _renterService.Update(formObject);
                return Content(JsonConvert.SerializeObject("/Renter/Index"));
            }
            catch (DbEntityValidationException ex)
            {
                this.SetUnprocessableEntityResponse();
                var presenter = new EntityValidationResultPresenter(ex);
                return this.Content(JsonConvert.SerializeObject(presenter));
            }
            
        }
        
        [HttpDelete]
        public ActionResult Delete(int renterID)
        {
            _renterService.Delete(renterID);
            return RedirectToAction("Index");
        }
    }
}