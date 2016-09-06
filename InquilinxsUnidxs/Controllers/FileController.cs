using InquilinxsUnidxs.Services;
using System.Web.Mvc;
using System.Web.Routing;

namespace InquilinxsUnidxs.Controllers
{
    public class FileController : ApplicationController
    {
        private FileService _fileService;

        protected override void Initialize(RequestContext requestContext)
        {
            _fileService = new FileService();
            base.Initialize(requestContext);
        }

        public ContentResult GetFileURL(int fileID)
        {
            return this.Content(_fileService.GetFileURL(fileID));
        }        
    }
}