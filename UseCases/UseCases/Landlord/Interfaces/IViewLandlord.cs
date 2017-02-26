using UseCases.Presenters;

namespace UseCases
{
    public interface IViewLandlord
    {
        LandlordPresenter Execute(int landlordID);
    }
}