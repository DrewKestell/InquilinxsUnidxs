namespace UseCases
{
    public class FileUseCases : IFileUseCases
    {
        public IGetFileUrl GetFileUrl { get; }
        public IUploadFile UploadFile { get; }

        public FileUseCases(IGetFileUrl getFileUrl, IUploadFile uploadFile)
        {
            GetFileUrl = getFileUrl;
            UploadFile = uploadFile;
        }
    }
}