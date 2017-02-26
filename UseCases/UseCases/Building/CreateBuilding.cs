using DataAccess.FormObject;
using Services;

namespace UseCases
{
    public class CreateBuilding : ICreateBuilding
    {
        readonly IBuildingService buildingService;

        public CreateBuilding(IBuildingService buildingService)
        {
            this.buildingService = buildingService;
        }

        public void Execute(BuildingFormObject formObject, int userID) => buildingService.Create(formObject, userID);
    }
}