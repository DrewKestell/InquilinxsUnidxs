namespace UseCases
{
    public interface IRenterUseCases
    {
        ICreateRenter CreateRenter { get; }
        IDeleteRenter DeleteRenter { get; }
        IEditRenter EditRenter { get; }
        IGetRenterExport GetRenterExport { get; }
        IGetRenters GetRenters { get; }
        INewRenter NewRenter { get; }
        IUpdateRenter UpdateRenter { get; }
        IViewRenter ViewRenter { get; }
    }
}