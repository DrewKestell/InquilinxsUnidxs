namespace UseCases
{
    public class NeighborhoodUseCases : INeighborhoodUseCases
    {
        public IGetNeighborhoods GetNeighborhoods { get; }
        public INewNeighborhood NewNeighborhood { get; }
        public IViewNeighborhood ViewNeighborhood { get; }
        public IEditNeighborhood EditNeighborhood { get; }
        public ICreateNeighborhood CreateNeighborhood { get; }
        public IUpdateNeighborhood UpdateNeighborhood { get; }
        public IDeleteNeighborhood DeleteNeighborhood { get; }

        public NeighborhoodUseCases(IGetNeighborhoods getNeighborhoods, INewNeighborhood newNeighborhood, IViewNeighborhood viewNeighborhood,
            IEditNeighborhood editNeighborhood, ICreateNeighborhood createNeighborhood, IUpdateNeighborhood updateNeighborhood,
            IDeleteNeighborhood deleteNeighborhood)
        {
            GetNeighborhoods = getNeighborhoods;
            NewNeighborhood = newNeighborhood;
            ViewNeighborhood = viewNeighborhood;
            EditNeighborhood = editNeighborhood;
            CreateNeighborhood = createNeighborhood;
            UpdateNeighborhood = updateNeighborhood;
            DeleteNeighborhood = deleteNeighborhood;
        }
    }
}