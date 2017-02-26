using UseCases.Presenters;

namespace UseCases
{
    public interface IGetMap
    {
        MapPresenter Execute(int? neighborhoodID, int? landlordID, string filter);
    }
}