using DataAccess.FormObject;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UseCases;
using UseCases.Presenters;

namespace InquilinxsUnidxs.Controllers
{
    public class NeighborhoodController : Controller
    {
        readonly INeighborhoodUseCases useCases;

        public NeighborhoodController(INeighborhoodUseCases useCases)
        {
            this.useCases = useCases;
        }

        [HttpGet]
        public ActionResult Index(int page = 1, int pageSize = 10) => View(useCases.GetNeighborhoods.Execute(page, pageSize));

        [HttpGet]
        public ActionResult New() => View(useCases.NewNeighborhood.Execute());

        [HttpGet]
        public ActionResult Detail(int neighborhoodID) => View(useCases.ViewNeighborhood.Execute(neighborhoodID));

        [HttpGet]
        public ActionResult Edit(int neighborhoodID) => View(useCases.EditNeighborhood.Execute(neighborhoodID));

        [HttpPost]
        public JsonResult Create(NeighborhoodFormObject formObject)
        {
            try
            {
                useCases.CreateNeighborhood.Execute(formObject);
                return Json("/Neighborhood/Index", JsonRequestBehavior.AllowGet);
            }
            catch (DbEntityValidationException ex)
            {
                SetUnprocessableEntityResponse();
                return Json(ex.EntityValidationErrors.Select(e => new EntityValidationErrorsPresenter(e)));
            }
        }

        [HttpPost]
        public JsonResult Update(NeighborhoodFormObject formObject)
        {
            try
            {
                useCases.UpdateNeighborhood.Execute(formObject);
                return Json("/Neighborhood/Index", JsonRequestBehavior.AllowGet);
            }
            catch (DbEntityValidationException ex)
            {
                SetUnprocessableEntityResponse();
                return Json(ex.EntityValidationErrors.Select(e => new EntityValidationErrorsPresenter(e)));
            }
        }

        [HttpDelete]
        public ActionResult Delete(int neighborhoodID)
        {
            useCases.DeleteNeighborhood.Execute(neighborhoodID);
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