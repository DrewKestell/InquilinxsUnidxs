using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InquilinxsUnidxs.Presenters
{
    public class MapPresenter
    {
        public List<MapBuildingPresenter> Buildings { get; private set; }

        public List<Tuple<int, string>> AllNeighborhoods { get; private set; }
        public List<Tuple<int, string>> AllLandlords { get; private set; }

        public MapPresenter(List<Building> buildings, List<Neighborhood> allNeighborhoods, List<Landlord> allLandlords)
        {
            Buildings = buildings.Select(b => new MapBuildingPresenter(b)).ToList();

            AllNeighborhoods = allNeighborhoods.Select(n => Tuple.Create(n.ID, n.Name)).ToList();
            AllLandlords = allLandlords.Select(l => Tuple.Create(l.ID, l.FullName)).ToList();
        }
    }
}