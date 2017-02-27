using DataAccess.Context;
using DataAccess.Model;
using Microsoft.WindowsAzure.Storage;
using System.Configuration;
using System.Web;

namespace Services
{
    public class FileService : IFileService
    {
        readonly IGenericRepository<File> fileRepository;
        readonly IUnitOfWork unitOfWork;

        public FileService(IGenericRepository<File> fileRepository, IUnitOfWork unitOfWork)
        {
            this.fileRepository = fileRepository;
            this.unitOfWork = unitOfWork;
        }

        public string GetFileUrl(int fileID) => ""; //fileRepository.Single(i => i.ID == fileID).SASURL();

        public void UploadFile(HttpPostedFileBase file)
        {
            var connectionString = ConfigurationManager.AppSettings["StorageConnectionString"];
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var blobContainer = blobClient.GetContainerReference("inquilinxsunidxs");
            var blockBlob = blobContainer.GetBlockBlobReference("testblob");

            blockBlob.UploadFromStream(file.InputStream);
        }
    }
}