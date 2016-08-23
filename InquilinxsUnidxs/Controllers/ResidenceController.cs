using DataAccess.FormObject;
using InquilinxsUnidxs.Presenters;
using InquilinxsUnidxs.Services;
using Newtonsoft.Json;
using System.Data.Entity.Validation;
using System.Web.Mvc;
using System.Web.Routing;

namespace InquilinxsUnidxs.Controllers
{
    public class ResidenceController : ApplicationController
    {
        private ResidenceService _residenceService;

        protected override void Initialize(RequestContext requestContext)
        {
            _residenceService = new ResidenceService();
            base.Initialize(requestContext);
        }

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var presenters = _residenceService.GetResidencePresenters(page, pageSize);
            return this.View(presenters);
        }

        public ActionResult New()
        {
            var presenter = _residenceService.GetNewResidencePresenter();
            return this.View(presenter);
        }

        public ActionResult Detail(int residenceID)
        {
            var presenter = _residenceService.GetResidencePresenter(residenceID);
            return this.View(presenter);
        }

        public ActionResult Edit(int residenceID)
        {
            var presenter = _residenceService.GetResidencePresenter(residenceID);
            return this.View(presenter);
        }

        [HttpPost]
        public ContentResult Create(ResidenceFormObject formObject)
        {
            try
            {
                _residenceService.Create(formObject);
                return this.Content(JsonConvert.SerializeObject("/Residence/Index"));
            }
            catch (DbEntityValidationException ex)
            {
                this.SetUnprocessableEntityResponse();
                var presenter = new EntityValidationResultPresenter(ex);
                return this.Content(JsonConvert.SerializeObject(presenter));
            }
        }

        [HttpPost]
        public ContentResult Update(ResidenceFormObject formObject)
        {
            try
            {
                _residenceService.Update(formObject);
                return Content(JsonConvert.SerializeObject("/Residence/Index"));
            }
            catch (DbEntityValidationException ex)
            {
                this.SetUnprocessableEntityResponse();
                var presenter = new EntityValidationResultPresenter(ex);
                return this.Content(JsonConvert.SerializeObject(presenter));
            }
        }

        [HttpDelete]
        public ActionResult Delete(int residenceID)
        {
            _residenceService.Delete(residenceID);
            return RedirectToAction("Index");
        }
    }
}