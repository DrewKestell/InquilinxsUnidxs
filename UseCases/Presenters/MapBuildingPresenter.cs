using Services.DTO;
using System.Linq;

namespace UseCases.Presenters
{
    public class MapBuildingPresenter
    {
        public int ID { get; }
        public string FullAddress { get; }
        public double Latitude { get; }
        public double Longitude { get; }
        public int LandlordID { get; }
        public string LandlordName { get; }
        public int NeighborhoodID { get; }
        public string NeighborhoodName { get; }
        public int ResidenceCount { get; }
        public int RenterCount { get; }

        public MapBuildingPresenter(BuildingDTO building)
        {
            ID = building.ID;
            FullAddress = building.FullAddress;
            Latitude = building.Latitude;
            Longitude = building.Longitude;
            LandlordID = building.Landlord.ID;
            LandlordName = building.Landlord.FullName;
            NeighborhoodID = building.Neighborhood.ID;
            NeighborhoodName = building.Neighborhood.Name;
            ResidenceCount = building.Residences.Count();
            RenterCount = building.Residences.SelectMany(r => r.Renters).Count();
        }
    }
}