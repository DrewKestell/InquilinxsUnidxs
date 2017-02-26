using DataAccess.FormObject;
using Services;

namespace UseCases
{
    public class UpdateNeighborhood : IUpdateNeighborhood
    {
        readonly INeighborhoodService neighborhoodService;

        public UpdateNeighborhood(INeighborhoodService neighborhoodService)
        {
            this.neighborhoodService = neighborhoodService;
        }

        public void Execute(NeighborhoodFormObject formObject) => neighborhoodService.Update(formObject);
    }
}