using System.Web;

namespace UseCases
{
    public interface IUploadFile
    {
        void Execute(HttpPostedFileBase file);
    }
}