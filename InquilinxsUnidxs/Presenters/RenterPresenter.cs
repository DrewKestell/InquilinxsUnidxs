using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InquilinxsUnidxs.Presenters
{
    public class RenterPresenter
    {
        public int ID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int BuildingID { get; private set; }
        public int ResidenceID { get; private set; }
        public string ResidenceName { get; private set; }
        public string Address { get; private set; }

        public List<Tuple<int, string, List<Tuple<int, string>>>> AllBuildings { get; private set; }

        public RenterPresenter(List<Building> allBuildings)
        {
            AllBuildings = allBuildings
                .Select(b => Tuple.Create(b.ID, b.FullAddress, b.Residences.Select(r => Tuple.Create(r.ID, r.Name)).ToList()))
                .ToList();
        }

        public RenterPresenter(Renter renter, List<Building> allBuildings) : this(allBuildings)
        {
            ID = renter.ID;
            FirstName = renter.FirstName;
            LastName = renter.LastName;
            BuildingID = renter.Residence.BuildingID;
            ResidenceID = renter.ResidenceID;
            ResidenceName = renter.Residence.Name;
            Address = renter.Residence.Building.FullAddress;
        }
    }
}