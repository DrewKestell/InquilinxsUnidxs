using UseCases.Presenters;

namespace UseCases
{
    public interface IGetResidences
    {
        PaginationPresenter<ResidencePresenter> Execute(int page, int pageSize);
    }
}