using System.Web;

namespace Services
{
    public interface IFileService
    {
        string GetFileUrl(int fileID);
        void UploadFile(HttpPostedFileBase file);
    }
}