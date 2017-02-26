using DataAccess.FormObject;
using Services.DTO;

namespace Services
{
    public interface INeighborhoodService
    {
        PaginationDTO<NeighborhoodDTO> GetNeighborhoods(int page, int pageSize);
        NeighborhoodDTO GetNeighborhood(int neighborhoodID);
        void Create(NeighborhoodFormObject formObject);
        void Update(NeighborhoodFormObject formObject);
        void Delete(int neighborhoodID);
    }
}