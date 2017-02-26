using DataAccess.Enum;
using Services;
using Services.DTO;
using System.Collections.Generic;
using UseCases.Presenters;

namespace UseCases
{
    public class ViewBuilding : IViewBuilding
    {
        readonly IBuildingService buildingService;

        public ViewBuilding(IBuildingService buildingService, ISuperTupleService superTupleService)
        {
            this.buildingService = buildingService;
        }

        public BuildingPresenter Execute(int buildingID) => 
            new BuildingPresenter(buildingService.GetBuilding(buildingID), new List<SuperTuple<int>>(), 
                new List<SuperTuple<int>>(), new List<SuperTuple<States>>());
    }
}