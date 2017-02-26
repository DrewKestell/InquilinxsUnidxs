using Services;

namespace UseCases
{
    public class  DeleteNeighborhoodAssociation : IDeleteNeighborhoodAssociation
    {
        readonly INeighborhoodAssociationService neighborhoodAssociationService;

        public DeleteNeighborhoodAssociation(INeighborhoodAssociationService neighborhoodAssociationService)
        {
            this.neighborhoodAssociationService = neighborhoodAssociationService;
        }

        public void Execute(int neighborhoodAssociationID) => 
            neighborhoodAssociationService.Delete(neighborhoodAssociationID);
    }
}