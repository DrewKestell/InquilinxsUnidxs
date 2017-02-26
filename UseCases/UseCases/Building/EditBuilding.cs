using DataAccess.Enum;
using Services;
using Services.DTO;
using System.Collections.Generic;
using UseCases.Presenters;

namespace UseCases
{
    public class EditBuilding : IEditBuilding
    {
        readonly IBuildingService buildingService;
        readonly IEnumerable<SuperTuple<States>> allStates;
        readonly IEnumerable<SuperTuple<int>> allLandlords;
        readonly IEnumerable<SuperTuple<int>> allNeighborhoods;

        public EditBuilding(IBuildingService buildingService, ISuperTupleService superTupleService)
        {
            this.buildingService = buildingService;
            allStates = superTupleService.GetAll(c => c.States);
            allLandlords = superTupleService.GetAll(c => c.Landlords);
            allNeighborhoods = superTupleService.GetAll(c => c.Neighborhoods);
        }

        public BuildingPresenter Execute(int buildingID) => 
            new BuildingPresenter(buildingService.GetBuilding(buildingID), allLandlords, allNeighborhoods, allStates);
    }
}