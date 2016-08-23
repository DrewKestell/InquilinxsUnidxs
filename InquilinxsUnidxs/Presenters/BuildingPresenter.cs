using DataAccess.Enum;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InquilinxsUnidxs.Presenters
{
    public class BuildingPresenter
    {
        public int ID { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string ZIP { get; private set; }
        public States? StateID { get; private set; }
        public string StateName { get; private set; }
        public string StateAbbreviation { get; private set; }
        public int LandlordID { get; private set; }
        public string LandlordName { get; private set; }
        public int NeighborhoodID { get; private set; }
        public string NeighborhoodName { get; private set; }
        public List<Tuple<string, int>> Residences { get; private set; }

        public List<Tuple<States, string>> AllStates { get; private set; }
        public List<Tuple<int, string>> AllLandlords { get; private set; }
        public List<Tuple<int, string>> AllNeighborhoods { get; private set; }

        public BuildingPresenter(List<State> allStates, List<Landlord> allLandlords, List<Neighborhood> allNeighborhoods)
        {
            AllStates = allStates.Select(s => Tuple.Create(s.ID, s.Abbreviation)).ToList();
            AllLandlords = allLandlords.Select(l => Tuple.Create(l.ID, l.FullName)).ToList();
            AllNeighborhoods = allNeighborhoods.Select(n => Tuple.Create(n.ID, n.Name)).ToList();
        }

        public BuildingPresenter(Building building, List<State> allStates, List<Landlord> allLandlords,
            List<Neighborhood> allNeighborhoods) : this(allStates, allLandlords, allNeighborhoods)
        {
            ID = building.ID;
            Address = building.Address;
            City = building.City;
            ZIP = building.ZIP;
            StateID = building.StateID;
            StateName = building.State.Name;
            StateAbbreviation = building.State.Abbreviation;
            LandlordID = building.LandlordID;
            LandlordName = building.Landlord.FullName;
            NeighborhoodID = building.NeighborhoodID;
            NeighborhoodName = building.Neighborhood.Name;
            Residences = building.Residences.Select(r => Tuple.Create(r.Name, r.ID)).ToList();
        }
    }
}