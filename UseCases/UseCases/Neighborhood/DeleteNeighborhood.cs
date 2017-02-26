using Services;

namespace UseCases
{
    public class DeleteNeighborhood : IDeleteNeighborhood
    {
        readonly INeighborhoodService neighborhoodService;

        public DeleteNeighborhood(INeighborhoodService neighborhoodService)
        {
            this.neighborhoodService = neighborhoodService;
        }

        public void Execute(int neighborhoodID) => neighborhoodService.Delete(neighborhoodID);
    }
}
