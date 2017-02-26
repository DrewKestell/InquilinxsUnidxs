using Services.DTO;
using System.Collections.Generic;
using System.Linq;

namespace UseCases.Presenters
{
    public class MapPresenter
    {
        public IEnumerable<MapBuildingPresenter> Buildings { get; }
        public IEnumerable<SuperTuple<int>> AllLandlords { get; }
        public IEnumerable<SuperTuple<int>> AllNeighborhoods { get; }
                
        public MapPresenter(IEnumerable<BuildingDTO> buildings, IEnumerable<SuperTuple<int>> allLandlords,
            IEnumerable<SuperTuple<int>> allNeighborhoods)
        {
            AllLandlords = allLandlords;
            AllNeighborhoods = allNeighborhoods;
            Buildings = buildings.Select(b => new MapBuildingPresenter(b));            
        }
    }
}