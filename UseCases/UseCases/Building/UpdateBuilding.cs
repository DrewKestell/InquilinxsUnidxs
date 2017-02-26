using DataAccess.FormObject;
using Services;

namespace UseCases
{
    public class UpdateBuilding : IUpdateBuilding
    {
        readonly IBuildingService buildingService;

        public UpdateBuilding(IBuildingService buildingService)
        {
            this.buildingService = buildingService;
        }

        public void Execute(BuildingFormObject formObject, int userID) => buildingService.Update(formObject, userID);
    }
}