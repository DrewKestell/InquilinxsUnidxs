using DataAccess.FormObject;
using Services;

namespace UseCases
{
    public class CreateNeighborhoodAssociation : ICreateNeighborhoodAssociation
    {
        readonly INeighborhoodAssociationService neighborhoodAssociationService;

        public CreateNeighborhoodAssociation(INeighborhoodAssociationService neighborhoodAssociationService)
        {
            this.neighborhoodAssociationService = neighborhoodAssociationService;
        }

        public void Execute(NeighborhoodAssociationFormObject formObject) =>
            neighborhoodAssociationService.Create(formObject);
    }
}