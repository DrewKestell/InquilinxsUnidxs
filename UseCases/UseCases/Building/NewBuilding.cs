using DataAccess.Enum;
using Services;
using Services.DTO;
using System.Collections.Generic;
using UseCases.Presenters;

namespace UseCases
{
    public class NewBuilding : INewBuilding
    {
        readonly IEnumerable<SuperTuple<States>> allStates;
        readonly IEnumerable<SuperTuple<int>> allLandlords;
        readonly IEnumerable<SuperTuple<int>> allNeighborhoods;

        public NewBuilding(ISuperTupleService superTupleService)
        {
            allStates = superTupleService.GetAll(c => c.States);
            allLandlords = superTupleService.GetAll(c => c.Landlords);
            allNeighborhoods = superTupleService.GetAll(c => c.Neighborhoods);
        }

        public BuildingPresenter Execute() => new BuildingPresenter(allLandlords, allNeighborhoods, allStates);
    }
}