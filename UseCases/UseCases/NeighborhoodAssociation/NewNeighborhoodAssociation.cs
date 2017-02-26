using Services;
using UseCases.Presenters;

namespace UseCases
{
    public class NewNeighborhoodAssociation : INewNeighborhoodAssociation
    {
        readonly INeighborhoodAssociationService neighborhoodAssociationService;

        public NewNeighborhoodAssociation(INeighborhoodAssociationService neighborhoodAssociationService)
        {
            this.neighborhoodAssociationService = neighborhoodAssociationService;
        }

        public NeighborhoodAssociationPresenter Execute() => new NeighborhoodAssociationPresenter();
    }
}