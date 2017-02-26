using DataAccess.FormObject;
using Services.DTO;

namespace Services
{
    public interface IBuildingService
    {
        PaginationDTO<BuildingDTO> GetBuildings(int page, int pageSize);
        BuildingDTO GetBuilding(int buildingID);
        void Create(BuildingFormObject formObject, int userID);
        void Update(BuildingFormObject formObject, int userID);
        void Delete(int buildingID);
    }
}