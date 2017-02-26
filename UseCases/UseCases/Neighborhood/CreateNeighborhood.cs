using DataAccess.FormObject;
using Services;

namespace UseCases
{
    public class CreateNeighborhood : ICreateNeighborhood
    {
        readonly INeighborhoodService neighborhoodService;

        public CreateNeighborhood(INeighborhoodService neighborhoodService)
        {
            this.neighborhoodService = neighborhoodService;
        }

        public void Execute(NeighborhoodFormObject formObject) => neighborhoodService.Create(formObject);
    }
}