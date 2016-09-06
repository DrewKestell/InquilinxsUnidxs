using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class FileService : Service
    {
        public string GetFileURL(int fileID)
        {
            using (var context = this.GetApplicationContext())
            {
                return context.Files.Single(i => i.ID == fileID).SASURL();
            }
        }
    }
}