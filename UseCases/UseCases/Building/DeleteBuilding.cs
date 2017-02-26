using Services;

namespace UseCases
{
    public class DeleteBuilding : IDeleteBuilding
    {
        readonly IBuildingService buildingService;

        public DeleteBuilding(IBuildingService buildingService)
        {
            this.buildingService = buildingService;
        }

        public void Execute(int buildingID) => buildingService.Delete(buildingID);
    }
}