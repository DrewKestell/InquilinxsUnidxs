using UseCases.Presenters;

namespace UseCases
{
    public interface IGetNeighborhoods
    {
        PaginationPresenter<NeighborhoodPresenter> Execute(int page, int pageSize);
    }
}