using DataAccess.FormObject;
using InquilinxsUnidxs.Presenters;
using InquilinxsUnidxs.Services;
using Newtonsoft.Json;
using System.Data.Entity.Validation;
using System.Web.Mvc;
using System.Web.Routing;

namespace InquilinxsUnidxs.Controllers
{
    public class LandlordController : ApplicationController
    {
        private LandlordService _landlordService;

        protected override void Initialize(RequestContext requestContext)
        {
            _landlordService = new LandlordService();
            base.Initialize(requestContext);
        }

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var presenters = _landlordService.GetLandlordPresenters(page, pageSize);
            return this.View(presenters);
        }

        public ActionResult New()
        {
            var presenter = _landlordService.GetNewLandlordPresenter();
            return this.View(presenter);
        }

        public ActionResult Detail(int landlordID)
        {
            var presenter = _landlordService.GetLandlordPresenter(landlordID);
            return this.View(presenter);
        }

        public ActionResult Edit(int landlordID)
        {
            var presenter = _landlordService.GetLandlordPresenter(landlordID);
            return this.View(presenter);
        }

        [HttpPost]
        public ContentResult Create(LandlordFormObject formObject)
        {
            try
            {
                _landlordService.Create(formObject);
                return this.Content(JsonConvert.SerializeObject("/Landlord/Index"));
            }
            catch (DbEntityValidationException ex)
            {
                this.SetUnprocessableEntityResponse();
                var presenter = new EntityValidationResultPresenter(ex);
                return this.Content(JsonConvert.SerializeObject(presenter));
            }
        }

        [HttpPost]
        public ContentResult Update(LandlordFormObject formObject)
        {
            try
            {
                _landlordService.Update(formObject);
                return Content(JsonConvert.SerializeObject("/Landlord/Index"));
            }
            catch (DbEntityValidationException ex)
            {
                this.SetUnprocessableEntityResponse();
                var presenter = new EntityValidationResultPresenter(ex);
                return this.Content(JsonConvert.SerializeObject(presenter));
            }
        }

        [HttpDelete]
        public ActionResult Delete(int landlordID)
        {
            _landlordService.Delete(landlordID);
            return RedirectToAction("Index");
        }
    }
}