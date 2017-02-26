using DataAccess.FormObject;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UseCases;
using UseCases.Presenters;

namespace InquilinxsUnidxs.Controllers
{
    public class PropertyManagementCompanyController : Controller
    {
        readonly IPropertyManagementCompanyUseCases useCases;

        public PropertyManagementCompanyController(IPropertyManagementCompanyUseCases useCases)
        {
            this.useCases = useCases;
        }

        [HttpGet]
        public ActionResult Index() => View(useCases.GetPropertyManagementCompanies.Execute());

        [HttpGet]
        public ActionResult New() => View(useCases.NewPropertyManagementCompany.Execute());

        [HttpGet]
        public ActionResult Detail(int propertyManagementCompanyID) =>
            View(useCases.ViewPropertyManagementCompany.Execute(propertyManagementCompanyID));

        [HttpGet]
        public ActionResult Edit(int propertyManagementCompanyID) =>
            View(useCases.EditPropertyManagementCompany.Execute(propertyManagementCompanyID));

        [HttpPost]
        public JsonResult Create(PropertyManagementCompanyFormObject formObject)
        {
            try
            {
                useCases.CreatePropertyManagementCompany.Execute(formObject, 1);  // FIXME: hardcoded UserID
                return Json("/PropertyManagementCompany/Index");
            }
            catch (DbEntityValidationException ex)
            {
                SetUnprocessableEntityResponse();
                return Json(ex.EntityValidationErrors.Select(e => new EntityValidationErrorsPresenter(e)));
            }
        }

        [HttpPost]
        public JsonResult Update(PropertyManagementCompanyFormObject formObject)
        {
            try
            {
                useCases.UpdatePropertyManagementCompany.Execute(formObject, 1); // FIXME: hardcoded UserID
                return Json("/PropertyManagementCompany/Index");
            }
            catch (DbEntityValidationException ex)
            {
                SetUnprocessableEntityResponse();
                return Json(ex.EntityValidationErrors.Select(e => new EntityValidationErrorsPresenter(e)));
            }
        }

        [HttpDelete]
        public ActionResult Delete(int propertyManagementCompanyID)
        {
            useCases.DeletePropertyManagementCompany.Execute(propertyManagementCompanyID);
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