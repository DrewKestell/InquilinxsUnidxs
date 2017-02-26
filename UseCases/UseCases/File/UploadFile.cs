using Services;
using System.Web;

namespace UseCases
{
    public class UploadFile : IUploadFile
    {
        readonly IFileService fileService;

        public UploadFile(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public void Execute(HttpPostedFileBase file) => fileService.UploadFile(file);
    }
}