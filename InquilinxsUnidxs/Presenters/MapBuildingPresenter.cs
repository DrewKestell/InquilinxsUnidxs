using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InquilinxsUnidxs.Presenters
{
    public class MapBuildingPresenter
    {
        public int ID { get; private set; }
        public string Address { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public MapBuildingPresenter(Building building)
        {
            ID = building.ID;
            Address = String.Format("{0}, {1}, {2}", building.Address, building.City, building.State.Abbreviation);
            Latitude = building.Latitude;
            Longitude = building.Longitude;
        }
    }
}