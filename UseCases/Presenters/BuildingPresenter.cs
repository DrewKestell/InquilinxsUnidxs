using DataAccess.Enum;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UseCases.Presenters
{
    public class BuildingPresenter
    {
        public string Address { get; }
        public IEnumerable<SuperTuple<int>> AllLandlords { get; }
        public IEnumerable<SuperTuple<int>> AllNeighborhoods { get; }
        public IEnumerable<SuperTuple<States>> AllStates { get; }
        public IEnumerable<CommentPresenter> BuildingComments { get; }
        public string City { get; }
        public int ID { get; }
        public int LandlordID { get; }
        public string LandlordName { get; }
        public int NeighborhoodID { get; }
        public string NeighborhoodName { get; }
        public IEnumerable<Tuple<int, string>> Residences { get; }
        public string StateAbbreviation { get; }
        public States? StateID { get; }
        public string StateName { get; }
        public string ZIP { get; }

        public BuildingPresenter(IEnumerable<SuperTuple<int>> allLandlords, IEnumerable<SuperTuple<int>> allNeighborhoods, 
            IEnumerable<SuperTuple<States>> allStates)
        {           
            AllLandlords = allLandlords;
            AllNeighborhoods = allNeighborhoods;
            AllStates = allStates;
        }

        public BuildingPresenter(BuildingDTO building, IEnumerable<SuperTuple<int>> allLandlords, IEnumerable<SuperTuple<int>> allNeighborhoods,
            IEnumerable<SuperTuple<States>> allStates) : this(allLandlords, allNeighborhoods, allStates)
        {            
            Address = building.Address;
            BuildingComments = building.BuildingComments.OrderByDescending(c => c.LastUpdated).Select(c => new CommentPresenter(c)).ToList();
            City = building.City;
            ID = building.ID;
            LandlordID = building.Landlord.ID;
            LandlordName = building.Landlord.FullName;
            NeighborhoodID = building.Neighborhood.ID;
            NeighborhoodName = building.Neighborhood.Name;
            Residences = building.Residences.Select(r => Tuple.Create(r.ID, r.Name)).ToList();
            StateAbbreviation = building.State.Abbreviation;
            StateID = building.State.ID;
            StateName = building.State.Name;
            ZIP = building.ZIP;          
        }
    }
}