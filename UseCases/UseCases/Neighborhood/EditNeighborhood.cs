using Services;
using UseCases.Presenters;

namespace UseCases
{
    public class EditNeighborhood : IEditNeighborhood
    {
        readonly INeighborhoodService neighborhoodService;

        public EditNeighborhood(INeighborhoodService neighborhoodService)
        {
            this.neighborhoodService = neighborhoodService;
        }

        public NeighborhoodPresenter Execute(int neighborhoodID) => 
            new NeighborhoodPresenter(neighborhoodService.GetNeighborhood(neighborhoodID));
    }
}