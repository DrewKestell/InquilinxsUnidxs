using UseCases.Presenters;

namespace UseCases
{
    public interface IGetLandlords
    {
        PaginationPresenter<LandlordPresenter> Execute(int page, int pageSize);
    }
}