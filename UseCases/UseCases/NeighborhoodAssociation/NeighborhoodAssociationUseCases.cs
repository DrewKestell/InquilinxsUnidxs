namespace UseCases
{
    public class NeighborhoodAssociationUseCases : INeighborhoodAssociationUseCases
    {
        public IGetNeighborhoodAssociations GetNeighborhoodAssociations { get; }
        public INewNeighborhoodAssociation NewNeighborhoodAssociation { get; }
        public IViewNeighborhoodAssociation ViewNeighborhoodAssociation { get; }
        public IEditNeighborhoodAssociation EditNeighborhoodAssociation { get; }
        public ICreateNeighborhoodAssociation CreateNeighborhoodAssociation { get; }
        public IUpdateNeighborhoodAssociation UpdateNeighborhoodAssociation { get; }
        public IDeleteNeighborhoodAssociation DeleteNeighborhoodAssociation { get; }

        public NeighborhoodAssociationUseCases(IGetNeighborhoodAssociations getNeighborhoodAssociations, INewNeighborhoodAssociation newNeighborhoodAssociation,
            IViewNeighborhoodAssociation viewNeighborhoodAssociation, IEditNeighborhoodAssociation editNeighborhoodAssociation,
            ICreateNeighborhoodAssociation createNeighborhoodAssociation, IUpdateNeighborhoodAssociation updateNeighborhoodAssociation,
            IDeleteNeighborhoodAssociation deleteNeighborhoodAssociation)
        {
            GetNeighborhoodAssociations = getNeighborhoodAssociations;
            NewNeighborhoodAssociation = newNeighborhoodAssociation;
            ViewNeighborhoodAssociation = viewNeighborhoodAssociation;
            EditNeighborhoodAssociation = editNeighborhoodAssociation;
            CreateNeighborhoodAssociation = createNeighborhoodAssociation;
            UpdateNeighborhoodAssociation = updateNeighborhoodAssociation;
            DeleteNeighborhoodAssociation = deleteNeighborhoodAssociation;
        }
    }
}