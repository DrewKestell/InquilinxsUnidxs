using DataAccess.FormObject;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UseCases;
using UseCases.Presenters;

namespace InquilinxsUnidxs.Controllers
{
    public class NeighborhoodAssociationController : Controller
    {
        readonly INeighborhoodAssociationUseCases useCases;

        public NeighborhoodAssociationController(INeighborhoodAssociationUseCases useCases)
        {
            this.useCases = useCases;
        }

        [HttpGet]
        public ActionResult Index() => View(useCases.GetNeighborhoodAssociations.Execute());

        [HttpGet]
        public ActionResult New() => View(useCases.NewNeighborhoodAssociation.Execute());

        [HttpGet]
        public ActionResult Detail(int neighborhoodAssociationID) => 
            View(useCases.ViewNeighborhoodAssociation.Execute(neighborhoodAssociationID));

        [HttpGet]
        public ActionResult Edit(int neighborhoodAssociationID) => 
            View(useCases.EditNeighborhoodAssociation.Execute(neighborhoodAssociationID));

        [HttpPost]
        public JsonResult Create(NeighborhoodAssociationFormObject formObject)
        {
            try
            {
                useCases.CreateNeighborhoodAssociation.Execute(formObject);
                return Json("/NeighborhoodAssociation/Index");
            }
            catch (DbEntityValidationException ex)
            {
                SetUnprocessableEntityResponse();
                return Json(ex.EntityValidationErrors.Select(e => new EntityValidationErrorsPresenter(e)));
            }
        }

        [HttpPost]
        public JsonResult Update(NeighborhoodAssociationFormObject formObject)
        {
            try
            {
                useCases.UpdateNeighborhoodAssociation.Execute(formObject);
                return Json("/NeighborhoodAssociation/Index");
            }
            catch (DbEntityValidationException ex)
            {
                SetUnprocessableEntityResponse();
                return Json(ex.EntityValidationErrors.Select(e => new EntityValidationErrorsPresenter(e)));
            }
        }

        [HttpDelete]
        public ActionResult Delete(int neighborhoodAssociationID)
        {
            useCases.DeleteNeighborhoodAssociation.Execute(neighborhoodAssociationID);
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