using Services;

namespace UseCases
{
    public class GetFileUrl : IGetFileUrl
    {
        readonly IFileService fileService;

        public GetFileUrl(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public string Execute(int fileID) => fileService.GetFileUrl(fileID);
    }
}