using DataAccess.FormObject;
using Services.DTO;

namespace Services
{
    public interface ILandlordService
    {
        PaginationDTO<LandlordDTO> GetLandlords(int page, int pageSize);
        LandlordDTO GetLandlord(int landlordID);
        void Create(LandlordFormObject formObject);
        void Update(LandlordFormObject formObject);
        void Delete(int landlordID);

    }
}