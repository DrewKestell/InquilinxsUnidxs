using DataAccess.FormObject;
using InquilinxsUnidxs.Presenters;
using InquilinxsUnidxs.Services;
using Newtonsoft.Json;
using System.Data.Entity.Validation;
using System.Web.Mvc;
using System.Web.Routing;

namespace InquilinxsUnidxs.Controllers
{
    public class NeighborhoodController : ApplicationController
    {
        private NeighborhoodService _neighborhoodService;

        protected override void Initialize(RequestContext requestContext)
        {
            _neighborhoodService = new NeighborhoodService();
            base.Initialize(requestContext);
        }

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var presenters = _neighborhoodService.GetNeighborhoodPresenters(page, pageSize);
            return this.View(presenters);
        }

        public ActionResult New()
        {
            var presenter = _neighborhoodService.GetNewNeighborhoodPresenter();
            return this.View(presenter);
        }

        public ActionResult Detail(int neighborhoodID)
        {
            var presenter = _neighborhoodService.GetNeighborhoodPresenter(neighborhoodID);
            return this.View(presenter);
        }

        public ActionResult Edit(int neighborhoodID)
        {
            var presenter = _neighborhoodService.GetNeighborhoodPresenter(neighborhoodID);
            return this.View(presenter);
        }

        [HttpPost]
        public ContentResult Create(NeighborhoodFormObject formObject)
        {
            try
            {
                _neighborhoodService.Create(formObject);
                return this.Content(JsonConvert.SerializeObject("/Neighborhood/Index"));
            }
            catch (DbEntityValidationException ex)
            {
                this.SetUnprocessableEntityResponse();
                var presenter = new EntityValidationResultPresenter(ex);
                return this.Content(JsonConvert.SerializeObject(presenter));
            }
        }

        [HttpPost]
        public ContentResult Update(NeighborhoodFormObject formObject)
        {
            try
            {
                _neighborhoodService.Update(formObject);
                return Content(JsonConvert.SerializeObject("/Neighborhood/Index"));
            }
            catch (DbEntityValidationException ex)
            {
                this.SetUnprocessableEntityResponse();
                var presenter = new EntityValidationResultPresenter(ex);
                return this.Content(JsonConvert.SerializeObject(presenter));
            }
        }

        [HttpDelete]
        public ActionResult Delete(int neighborhoodID)
        {
            _neighborhoodService.Delete(neighborhoodID);
            return RedirectToAction("Index");
        }
    }
}