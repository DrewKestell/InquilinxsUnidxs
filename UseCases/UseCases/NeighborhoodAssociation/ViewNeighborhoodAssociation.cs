using Services;
using UseCases.Presenters;

namespace UseCases
{
    public class ViewNeighborhoodAssociation : IViewNeighborhoodAssociation
    {
        readonly INeighborhoodAssociationService neighborhoodAssociationService;

        public ViewNeighborhoodAssociation(INeighborhoodAssociationService neighborhoodAssociationService)
        {
            this.neighborhoodAssociationService = neighborhoodAssociationService;
        }

        public NeighborhoodAssociationPresenter Execute(int neighborhoodAssociationID) =>
            new NeighborhoodAssociationPresenter(neighborhoodAssociationService.GetNeighborhoodAssociation(neighborhoodAssociationID));
    }
}