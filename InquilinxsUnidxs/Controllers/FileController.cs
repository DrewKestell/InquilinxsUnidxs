using System.Web;
using System.Web.Mvc;
using UseCases;

namespace InquilinxsUnidxs.Controllers
{
    public class FileController : Controller
    {
        readonly IFileUseCases useCases;

        public FileController(IFileUseCases useCases)
        {
            this.useCases = useCases;
        }

        [HttpGet]
        public ContentResult GetFileURL(int fileID)
        {
            return Content(useCases.GetFileUrl.Execute(fileID));
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            useCases.UploadFile.Execute(file);
            return null; // FIXME: return null?
        }
    }
}