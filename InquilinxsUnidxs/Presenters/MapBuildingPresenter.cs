using DataAccess.Model;
using System;
using System.Linq;

namespace InquilinxsUnidxs.Presenters
{
    public class MapBuildingPresenter
    {
        public int ID { get; private set; }
        public string FullAddress { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public int LandlordID { get; private set; }
        public string LandlordName { get; private set; }
        public int NeighborhoodID { get; private set; }
        public string NeighborhoodName { get; private set; }
        public int ResidenceCount { get; private set; }
        public int RenterCount { get; private set; }

        public MapBuildingPresenter(Building building)
        {
            ID = building.ID;
            FullAddress = String.Format("{0}, {1}, {2}", building.Address, building.City, building.State.Abbreviation);
            Latitude = building.Latitude;
            Longitude = building.Longitude;
            LandlordID = building.LandlordID;
            LandlordName = building.Landlord.FullName;
            NeighborhoodID = building.NeighborhoodID;
            NeighborhoodName = building.Neighborhood.Name;
            ResidenceCount = building.Residences.Count();
            RenterCount = building.Residences.SelectMany(r => r.Renters).Count();
        }
    }
}