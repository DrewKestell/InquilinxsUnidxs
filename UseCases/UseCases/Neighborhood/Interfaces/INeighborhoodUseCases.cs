namespace UseCases
{
    public interface INeighborhoodUseCases
    {
        IGetNeighborhoods GetNeighborhoods { get; }
        INewNeighborhood NewNeighborhood { get; }
        IViewNeighborhood ViewNeighborhood { get; }
        IEditNeighborhood EditNeighborhood { get; }
        ICreateNeighborhood CreateNeighborhood { get; }
        IUpdateNeighborhood UpdateNeighborhood { get; }
        IDeleteNeighborhood DeleteNeighborhood { get; }
    }
}