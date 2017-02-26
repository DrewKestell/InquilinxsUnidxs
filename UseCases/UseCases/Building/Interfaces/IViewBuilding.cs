using UseCases.Presenters;

namespace UseCases
{
    public interface IViewBuilding
    {
        BuildingPresenter Execute(int buildingID);
    }
}