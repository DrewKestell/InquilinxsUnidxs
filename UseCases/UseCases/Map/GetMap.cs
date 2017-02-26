using Services;
using Services.DTO;
using System.Collections.Generic;
using UseCases.Presenters;

namespace UseCases
{
    public class GetMap : IGetMap
    {
        readonly IMapService mapService;
        readonly IEnumerable<SuperTuple<int>> allLandlords;
        readonly IEnumerable<SuperTuple<int>> allNeighborhoods;        

        public GetMap(IMapService mapService, ISuperTupleService superTupleService)
        {
            this.mapService = mapService;
            allLandlords = superTupleService.GetAll(c => c.Landlords);
            allNeighborhoods = superTupleService.GetAll(c => c.Neighborhoods);           
        }

        public MapPresenter Execute(int? neighborhoodID, int? landlordID, string filter) =>
            new MapPresenter(mapService.GetBuildings(neighborhoodID, landlordID, filter), allLandlords, allNeighborhoods);
    }
}