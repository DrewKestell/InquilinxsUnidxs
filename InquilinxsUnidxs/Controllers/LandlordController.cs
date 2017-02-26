using DataAccess.FormObject;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UseCases;
using UseCases.Presenters;

namespace InquilinxsUnidxs.Controllers
{
    public class LandlordController : Controller
    {
        readonly ILandlordUseCases useCases;

        public LandlordController(ILandlordUseCases useCases)
        {
            this.useCases = useCases;
        }

        [HttpGet]
        public ActionResult Index(int page = 1, int pageSize = 10) => View(useCases.GetLandlords.Execute(page, pageSize));

        [HttpGet]
        public ActionResult New() => View(useCases.NewLandlord.Execute());

        [HttpGet]
        public ActionResult Detail(int landlordID) => View(useCases.ViewLandlord.Execute(landlordID));

        [HttpGet]
        public ActionResult Edit(int landlordID) => View(useCases.EditLandlord.Execute(landlordID));

        [HttpPost]
        public JsonResult Create(LandlordFormObject formObject)
        {
            try
            {
                useCases.CreateLandlord.Execute(formObject);
                return Json("/Landlord/Index", JsonRequestBehavior.AllowGet);
            }
            catch (DbEntityValidationException ex)
            {
                SetUnprocessableEntityResponse();
                return Json(ex.EntityValidationErrors.Select(e => new EntityValidationErrorsPresenter(e)));
            }
        }

        [HttpPost]
        public JsonResult Update(LandlordFormObject formObject)
        {
            try
            {
                useCases.UpdateLandlord.Execute(formObject);
                return Json("/Landlord/Index", JsonRequestBehavior.AllowGet);
            }
            catch (DbEntityValidationException ex)
            {
                SetUnprocessableEntityResponse();
                return Json(ex.EntityValidationErrors.Select(e => new EntityValidationErrorsPresenter(e)));
            }
        }

        [HttpDelete]
        public ActionResult Delete(int landlordID)
        {
            useCases.DeleteLandlord.Execute(landlordID);
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