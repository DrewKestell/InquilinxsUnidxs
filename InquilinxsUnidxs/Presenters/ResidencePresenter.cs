using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InquilinxsUnidxs.Presenters
{
    public class ResidencePresenter
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public int BuildingID { get; private set; }
        public string BuildingAddress { get; private set; }
        public List<Tuple<int, string>> Renters { get; private set; }

        public List<Tuple<int, string>> AllBuildings { get; private set; }

        public ResidencePresenter(List<Building> allBuildings)
        {
            AllBuildings = allBuildings
                .Select(b => Tuple.Create(b.ID, b.FullAddress))
                .OrderBy(b => b.Item2)
                .ToList();
        }

        public ResidencePresenter(Residence residence, List<Building> allBuildings) : this(allBuildings)
        {
            ID = residence.ID;
            Name = residence.Name;
            BuildingID = residence.BuildingID;
            BuildingAddress = residence.Building.FullAddress;
            Renters = residence.Renters.Select(r => Tuple.Create(r.ID, r.FullName)).ToList();
        }
    }
}