using UseCases.Presenters;

namespace UseCases
{
    public interface IEditLandlord
    {
        LandlordPresenter Execute(int landlordID);
    }
}