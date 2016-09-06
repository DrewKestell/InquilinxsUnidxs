using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InquilinxsUnidxs.Services
{
    public class FileService : DataAccess.Service.FileService
    {
        public new string GetFileURL(int fileID)
        {
            return base.GetFileURL(fileID);
        }
    }
}