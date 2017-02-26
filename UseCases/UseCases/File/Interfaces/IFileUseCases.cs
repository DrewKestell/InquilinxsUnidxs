namespace UseCases
{
    public interface IFileUseCases
    {
        IGetFileUrl GetFileUrl { get; }
        IUploadFile UploadFile { get; }
    }
}