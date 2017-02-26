using DataAccess.FormObject;
using Services.DTO;

namespace Services
{
    public interface IResidenceService
    {
        PaginationDTO<ResidenceDTO> GetResidences(int page, int pageSize);
        ResidenceDTO GetResidence(int residenceID);
        void Create(ResidenceFormObject formObject, int userID);
        void Update(ResidenceFormObject formObject, int userID);
        void Delete(int residenceID);
    }
}