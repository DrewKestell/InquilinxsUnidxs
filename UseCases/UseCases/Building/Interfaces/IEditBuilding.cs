using UseCases.Presenters;

namespace UseCases
{
    public interface IEditBuilding
    {
        BuildingPresenter Execute(int buildingID);
    }
}