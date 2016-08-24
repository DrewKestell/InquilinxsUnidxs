using DataAccess.FormObject;
using InquilinxsUnidxs.Presenters;
using InquilinxsUnidxs.Services;
using Newtonsoft.Json;
using System.Data.Entity.Validation;
using System.Web.Mvc;
using System.Web.Routing;

namespace InquilinxsUnidxs.Controllers
{
    public class BuildingController : ApplicationController
    {
        private BuildingService _buildingService;

        protected override void Initialize(RequestContext requestContext)
        {
            _buildingService = new BuildingService();
            base.Initialize(requestContext);
        }

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var presenters = _buildingService.GetBuildingPresenters(page, pageSize);
            return this.View(presenters);
        }

        public ActionResult New()
        {
            var presenter = _buildingService.GetNewBuildingPresenter();
            return this.View(presenter);
        }

        public ActionResult Detail(int buildingID)
        {
            var presenter = _buildingService.GetBuildingPresenter(buildingID);
            return this.View(presenter);
        }

        public ActionResult Edit(int buildingID)
        {
            var presenter = _buildingService.GetBuildingPresenter(buildingID);
            return this.View(presenter);
        }

        [HttpPost]
        public ContentResult Create(BuildingFormObject formObject)
        {
            try
            {
                _buildingService.Create(formObject);
                return this.Content(JsonConvert.SerializeObject("/Building/Index"));
            }
            catch (DbEntityValidationException ex)
            {
                this.SetUnprocessableEntityResponse();
                var presenter = new EntityValidationResultPresenter(ex);
                return this.Content(JsonConvert.SerializeObject(presenter));
            }
        }

        [HttpPost]
        public ContentResult Update(BuildingFormObject formObject)
        {
            try
            {
                _buildingService.Update(formObject);
                return Content(JsonConvert.SerializeObject("/Building/Index"));
            }
            catch (DbEntityValidationException ex)
            {
                this.SetUnprocessableEntityResponse();
                var presenter = new EntityValidationResultPresenter(ex);
                return this.Content(JsonConvert.SerializeObject(presenter));
            }
        }

        [HttpDelete]
        public ActionResult Delete(int buildingID)
        {
            _buildingService.Delete(buildingID);
            return RedirectToAction("Index");
        }
    }
}