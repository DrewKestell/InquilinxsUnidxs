using Services;
using UseCases.Presenters;

namespace UseCases
{
    public class EditNeighborhoodAssociation : IEditNeighborhoodAssociation
    {
        readonly INeighborhoodAssociationService neighborhoodAssociationService;

        public EditNeighborhoodAssociation(INeighborhoodAssociationService neighborhoodAssociationService)
        {
            this.neighborhoodAssociationService = neighborhoodAssociationService;
        }

        public NeighborhoodAssociationPresenter Execute(int neighborhoodAssociationID) =>
            new NeighborhoodAssociationPresenter(neighborhoodAssociationService.GetNeighborhoodAssociation(neighborhoodAssociationID));
    }
}