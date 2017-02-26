namespace UseCases
{
    public class LandlordUseCases : ILandlordUseCases
    {
        public IGetLandlords GetLandlords { get; }
        public INewLandlord NewLandlord { get; }
        public IViewLandlord ViewLandlord { get; }
        public IEditLandlord EditLandlord { get; }
        public ICreateLandlord CreateLandlord { get; }
        public IUpdateLandlord UpdateLandlord { get; }
        public IDeleteLandlord DeleteLandlord { get; }

        public LandlordUseCases(IGetLandlords getLandlords, INewLandlord newLandlord, IViewLandlord viewLandlord, IEditLandlord editLandlord,
            ICreateLandlord createLandlord, IUpdateLandlord updateLandlord, IDeleteLandlord deleteLandlord)
        {
            GetLandlords = getLandlords;
            NewLandlord = newLandlord;
            ViewLandlord = viewLandlord;
            EditLandlord = editLandlord;
            CreateLandlord = createLandlord;
            UpdateLandlord = updateLandlord;
            DeleteLandlord = deleteLandlord;
        }
    }
}