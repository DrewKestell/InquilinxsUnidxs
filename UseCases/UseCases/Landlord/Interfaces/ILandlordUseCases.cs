namespace UseCases
{
    public interface ILandlordUseCases
    {
        IGetLandlords GetLandlords { get; }
        INewLandlord NewLandlord { get; }
        IViewLandlord ViewLandlord { get; }
        IEditLandlord EditLandlord { get; }
        ICreateLandlord CreateLandlord { get; }
        IUpdateLandlord UpdateLandlord { get; }
        IDeleteLandlord DeleteLandlord { get; }
    }
}