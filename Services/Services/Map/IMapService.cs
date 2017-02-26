using DataAccess.FormObject;
using Services.DTO;
using System.Collections.Generic;

namespace Services
{
    public interface IMapService
    {
        IEnumerable<BuildingDTO> GetBuildings(int? neighborhoodID, int? landlordID, string filter);
        void UpdateGeolocation(IEnumerable<MapBuildingFormObject> formObjects);
    }
}