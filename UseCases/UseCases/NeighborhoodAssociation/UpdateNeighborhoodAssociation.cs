using DataAccess.FormObject;
using Services;

namespace UseCases
{
    public class UpdateNeighborhoodAssociation : IUpdateNeighborhoodAssociation
    {
        readonly INeighborhoodAssociationService neighborhoodAssociationService;

        public UpdateNeighborhoodAssociation(INeighborhoodAssociationService neighborhoodAssociationService)
        {
            this.neighborhoodAssociationService = neighborhoodAssociationService;
        }

        public void Execute(NeighborhoodAssociationFormObject formObject) =>
            neighborhoodAssociationService.Create(formObject);
    }
}