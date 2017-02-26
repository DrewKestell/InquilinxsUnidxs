using Services;
using UseCases.Presenters;

namespace UseCases
{
    public class NewNeighborhood : INewNeighborhood
    {
        readonly INeighborhoodService neighborhoodService;

        public NewNeighborhood(INeighborhoodService neighborhoodService)
        {
            this.neighborhoodService = neighborhoodService;
        }

        public NeighborhoodPresenter Execute() => new NeighborhoodPresenter();
    }
}