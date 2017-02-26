using DataAccess.CustomConventions;
using DataAccess.Enum;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace DataAccess.Model
{
    public class File
    {
        public int ID { get; set; }

        [Required, MaxLength(1000), Index(IsUnique = true)]
        public string URL { get; set; }

        public FileTypes FileTypeID { get; set; }

        public int? BuildingID { get; set; }

        public int? ResidenceID { get; set; }

        public virtual Building Building { get; set; }

        [CascadeDelete]
        public virtual FileType FileType { get; set; }

        public virtual Residence Residence { get; set; }

        public string SASURL()
        {
            var connectionString = ConfigurationManager.AppSettings["StorageConnectionString"];
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("inquilinxsunidxs");

            SharedAccessBlobPolicy policy = new SharedAccessBlobPolicy()
            {
                Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.List,
                SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24)
            };

            return URL + container.GetSharedAccessSignature(policy);
        }
    }
}