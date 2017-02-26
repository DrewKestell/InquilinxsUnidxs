using DataAccess.FormObject;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UseCases;
using UseCases.Presenters;

namespace InquilinxsUnidxs.Controllers
{
    public class ResidenceController : Controller
    {
        readonly IResidenceUseCases useCases;

        public ResidenceController(IResidenceUseCases useCases)
        {
            this.useCases = useCases;
        }

        [HttpGet]
        public ActionResult Index(int page = 1, int pageSize = 10) => View(useCases.GetResidences.Execute(page, pageSize));

        [HttpGet]
        public ActionResult New() => View(useCases.NewResidence.Execute());

        [HttpGet]
        public ActionResult Detail(int residenceID) => View(useCases.ViewResidence.Execute(residenceID));

        [HttpGet]
        public ActionResult Edit(int residenceID) => View(useCases.EditResidence.Execute(residenceID));

        [HttpPost]
        public JsonResult Create(ResidenceFormObject formObject)
        {
            try
            {
                useCases.CreateResidence.Execute(formObject, 1); // FIXME: this should pass in the current user ID
                return Json("/Residence/Index", JsonRequestBehavior.AllowGet);
            }
            catch (DbEntityValidationException ex)
            {
                SetUnprocessableEntityResponse();
                return Json(ex.EntityValidationErrors.Select(e => new EntityValidationErrorsPresenter(e)));
            }
        }

        [HttpPost]
        public JsonResult Update(ResidenceFormObject formObject)
        {
            try
            {
                useCases.UpdateResidence.Execute(formObject, 1); // FIXME: this should pass in the current user ID
                return Json("/Residence/Index", JsonRequestBehavior.AllowGet);
            }
            catch (DbEntityValidationException ex)
            {
                SetUnprocessableEntityResponse();
                return Json(ex.EntityValidationErrors.Select(e => new EntityValidationErrorsPresenter(e)));
            }
        }

        [HttpDelete]
        public ActionResult Delete(int residenceID)
        {
            useCases.DeleteResidence.Execute(residenceID);
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