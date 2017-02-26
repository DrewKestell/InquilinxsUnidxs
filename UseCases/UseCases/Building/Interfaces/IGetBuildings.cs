using UseCases.Presenters;

namespace UseCases
{
    public interface IGetBuildings
    {
        PaginationPresenter<BuildingPresenter> Execute(int page, int pageSize);
    }
}