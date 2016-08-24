using DataAccess.FormObject;
using InquilinxsUnidxs.Presenters;
using InquilinxsUnidxs.Services;
using Newtonsoft.Json;
using System.Data.Entity.Validation;
using System.Web.Mvc;
using System.Web.Routing;

namespace InquilinxsUnidxs.Controllers
{
    public class RenterController : ApplicationController
    {
        private RenterService _renterService;

        protected override void Initialize(RequestContext requestContext)
        {            
            _renterService = new RenterService();
            base.Initialize(requestContext);
        }

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var presenters = _renterService.GetRenterPresenters(page, pageSize);
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