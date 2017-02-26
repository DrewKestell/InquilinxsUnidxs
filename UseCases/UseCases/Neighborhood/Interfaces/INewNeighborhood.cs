using UseCases.Presenters;

namespace UseCases
{
    public interface INewNeighborhood
    {
        NeighborhoodPresenter Execute();
    }
}