using DataAccess.FormObject;
using Services.DTO;
using System.Collections.Generic;

namespace Services
{
    public interface IRenterService
    {
        PaginationDTO<RenterDTO> GetRenters(int page, int pageSize, string filter);
        IEnumerable<BuildingDTO> GetBuildings();
        RenterDTO GetRenter(int renterID);
        void Create(RenterFormObject formObject);
        void Update(RenterFormObject formObject);
        void Delete(int renterID);
        string GetRenterExport();
    }
}