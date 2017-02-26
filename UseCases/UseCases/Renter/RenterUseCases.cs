namespace UseCases
{
    public class RenterUseCases : IRenterUseCases
    {
        public ICreateRenter CreateRenter { get; }
        public IDeleteRenter DeleteRenter { get; }
        public IEditRenter EditRenter { get; }
        public IGetRenterExport GetRenterExport { get; }
        public IGetRenters GetRenters { get; }
        public INewRenter NewRenter { get; }
        public IUpdateRenter UpdateRenter { get; }
        public IViewRenter ViewRenter { get; }

        public RenterUseCases(ICreateRenter createRenter, IDeleteRenter deleteRenter, IEditRenter editRenter, IGetRenters getRenters,
            INewRenter newRenter, IUpdateRenter updateRenter, IViewRenter viewRenter, IGetRenterExport getRenterExport)
        {
            CreateRenter = createRenter;
            DeleteRenter = deleteRenter;
            EditRenter = editRenter;
            GetRenterExport = getRenterExport;
            GetRenters = getRenters;
            NewRenter = newRenter;
            UpdateRenter = updateRenter;
            ViewRenter = viewRenter;
        }
    }
}