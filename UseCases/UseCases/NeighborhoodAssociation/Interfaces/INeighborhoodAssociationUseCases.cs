namespace UseCases
{
    public interface INeighborhoodAssociationUseCases
    {
        IGetNeighborhoodAssociations GetNeighborhoodAssociations { get; }
        INewNeighborhoodAssociation NewNeighborhoodAssociation { get; }
        IViewNeighborhoodAssociation ViewNeighborhoodAssociation { get; }
        IEditNeighborhoodAssociation EditNeighborhoodAssociation { get; }
        ICreateNeighborhoodAssociation CreateNeighborhoodAssociation { get; }
        IUpdateNeighborhoodAssociation UpdateNeighborhoodAssociation { get; }
        IDeleteNeighborhoodAssociation DeleteNeighborhoodAssociation { get; }
    }
}