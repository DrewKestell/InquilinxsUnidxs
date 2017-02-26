using UseCases.Presenters;

namespace UseCases
{
    public interface IEditNeighborhood
    {
        NeighborhoodPresenter Execute(int neighborhoodID);
    }
}