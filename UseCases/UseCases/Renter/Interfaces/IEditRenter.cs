using UseCases.Presenters;

namespace UseCases
{
    public interface IEditRenter
    {
        RenterPresenter Execute(int renterID);
    }
}