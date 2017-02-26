using DataAccess.FormObject;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UseCases;
using UseCases.Presenters;

namespace InquilinxsUnidxs.Controllers
{
    public class RenterController : Controller
    {
        readonly IRenterUseCases useCases;

        public RenterController(IRenterUseCases useCases)
        {
            this.useCases = useCases;
        }

        [HttpGet]
        public ActionResult Index(int page = 1, int pageSize = 10, string filter = "") => 
            View(useCases.GetRenters.Execute(page, pageSize, filter));

        [HttpGet]
        public ActionResult New() => View(useCases.NewRenter.Execute());

        [HttpGet]
        public ActionResult Detail(int renterID) => View(useCases.ViewRenter.Execute(renterID));

        [HttpGet]
        public ActionResult Edit(int renterID) => View(useCases.EditRenter.Execute(renterID));

        [HttpGet]
        public ActionResult GetCsvExport()
        {
            var csv = useCases.GetRenterExport.Execute();

            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=template.csv");
            Response.ContentType = "text/csv";
            Response.Write(csv);
            Response.End();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public JsonResult Create(RenterFormObject formObject)
        {
            try
            {
                useCases.CreateRenter.Execute(formObject);
                return Json("/Renter/Index", JsonRequestBehavior.AllowGet);
            }
            catch (DbEntityValidationException ex)
            {
                SetUnprocessableEntityResponse();
                return Json(ex.EntityValidationErrors.Select(e => new EntityValidationErrorsPresenter(e)));
            }
        }

        [HttpPost]
        public JsonResult Update(RenterFormObject formObject)
        {
            try
            {
                useCases.UpdateRenter.Execute(formObject);
                return Json("/Renter/Index", JsonRequestBehavior.AllowGet);
            }
            catch (DbEntityValidationException ex)
            {
                SetUnprocessableEntityResponse();
                return Json(ex.EntityValidationErrors.Select(e => new EntityValidationErrorsPresenter(e)));
            }
        }

        [HttpDelete]
        public ActionResult Delete(int renterID)
        {
            useCases.DeleteRenter.Execute(renterID);
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