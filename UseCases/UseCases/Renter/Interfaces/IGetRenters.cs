using UseCases.Presenters;

namespace UseCases
{
    public interface IGetRenters
    {
        RenterIndexPresenter Execute(int page, int pageSize, string filter);
    }
}