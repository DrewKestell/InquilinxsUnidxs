using InquilinxsUnidxs.Presenters;

namespace InquilinxsUnidxs.Services
{
    public class MapService : DataAccess.Service.MapService
    {
        public MapPresenter GetMapPresenter(int? neighborhoodID, int? landlordID, string filter)
        {
            var buildings = base.GetBuildings(neighborhoodID, landlordID, filter);
            var neighborhoods = base.GetNeighborhoods();
            var landlords = base.GetLandlords();
            return new MapPresenter(buildings, neighborhoods, landlords);
        }       
    }
}