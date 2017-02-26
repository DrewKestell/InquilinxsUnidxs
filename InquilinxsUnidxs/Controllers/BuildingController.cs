using DataAccess.FormObject;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UseCases;
using UseCases.Presenters;

namespace InquilinxsUnidxs.Controllers
{
    public class BuildingController : Controller
    {
        readonly IBuildingUseCases useCases;

        public BuildingController(IBuildingUseCases useCases)
        {
            this.useCases = useCases;
        }

        [HttpGet]
        public ActionResult Index(int page = 1, int pageSize = 10) => View(useCases.GetBuildings.Execute(page, pageSize));

        [HttpGet]
        public ActionResult New() => View(useCases.NewBuilding.Execute());

        [HttpGet]
        public ActionResult Detail(int buildingID) => View(useCases.ViewBuilding.Execute(buildingID));

        [HttpGet]
        public ActionResult Edit(int buildingID) => View(useCases.EditBuilding.Execute(buildingID));

        [HttpPost]
        public JsonResult Create(BuildingFormObject formObject)
        {
            try
            {
                useCases.CreateBuilding.Execute(formObject, 1); // FIXME: hardcoded UserID
                return Json("/Building/Index");
            }
            catch (DbEntityValidationException ex)
            {
                SetUnprocessableEntityResponse();
                return Json(ex.EntityValidationErrors.Select(e => new EntityValidationErrorsPresenter(e)));
            }
        }

        [HttpPost]
        public JsonResult Update(BuildingFormObject formObject)
        {
            try
            {
                useCases.UpdateBuilding.Execute(formObject, 1); // FIXME: hardcoded UserID
                return Json("/Building/Index");
            }
            catch (DbEntityValidationException ex)
            {
                SetUnprocessableEntityResponse();
                return Json(ex.EntityValidationErrors.Select(e => new EntityValidationErrorsPresenter(e)));
            }
        }

        [HttpDelete]
        public ActionResult Delete(int buildingID)
        {
            useCases.DeleteBuilding.Execute(buildingID);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        // FIXME: DRY me up!
        const string status = "422 Unprocessable Entity";
        const int statusCode = 422;
        const string statusDescription = "Entity validation failed. See errors for details.";

        void SetUnprocessableEntityResponse()
        {
            Response.Status = status;
            Response.StatusCode = statusCode;
            Response.StatusDescription = statusDescription;
        }
    }
}