using UseCases.Presenters;

namespace UseCases
{
    public interface IViewRenter
    {
        RenterPresenter Execute(int renterID);
    }
}