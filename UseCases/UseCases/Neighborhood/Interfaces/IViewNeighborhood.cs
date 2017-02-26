using UseCases.Presenters;

namespace UseCases
{
    public interface IViewNeighborhood
    {
        NeighborhoodPresenter Execute(int neighborhoodID);
    }
}