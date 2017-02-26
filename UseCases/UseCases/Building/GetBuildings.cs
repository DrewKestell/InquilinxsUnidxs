using DataAccess.Enum;
using Services;
using Services.DTO;
using System.Collections.Generic;
using System.Linq;
using UseCases.Presenters;

namespace UseCases
{
    public class GetBuildings : IGetBuildings
    {
        readonly IBuildingService buildingService;
        readonly IEnumerable<SuperTuple<States>> allStates;
        readonly IEnumerable<SuperTuple<int>> allLandlords;
        readonly IEnumerable<SuperTuple<int>> allNeighborhoods;

        public GetBuildings(IBuildingService buildingService, ISuperTupleService superTupleService)
        {
            this.buildingService = buildingService;
            allStates = superTupleService.GetAll(c => c.States);
            allLandlords = superTupleService.GetAll(c => c.Landlords);
            allNeighborhoods = superTupleService.GetAll(c => c.Neighborhoods);
        }

        public PaginationPresenter<BuildingPresenter> Execute(int page, int pageSize)
        {
            var buildings = buildingService.GetBuildings(page, pageSize);
            var buildingPresenters = buildings.Model.Select(m => new BuildingPresenter(m, allLandlords, allNeighborhoods, allStates));
            var paginationInfo = new PaginationInfo(page, pageSize, buildings.TotalRecords, buildings.TotalPages);
            return new PaginationPresenter<BuildingPresenter>(buildingPresenters, paginationInfo);
        }
    }
}