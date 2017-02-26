using Services;
using UseCases.Presenters;

namespace UseCases
{
    public class ViewNeighborhood : IViewNeighborhood
    {
        readonly INeighborhoodService neighborhoodService;

        public ViewNeighborhood(INeighborhoodService neighborhoodService)
        {
            this.neighborhoodService = neighborhoodService;
        }

        public NeighborhoodPresenter Execute(int neighborhoodID) => 
            new NeighborhoodPresenter(neighborhoodService.GetNeighborhood(neighborhoodID));
    }
}