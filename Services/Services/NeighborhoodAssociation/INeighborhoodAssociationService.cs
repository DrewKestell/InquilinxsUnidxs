using DataAccess.FormObject;
using Services.DTO;
using System.Collections.Generic;

namespace Services
{
    public interface INeighborhoodAssociationService
    {
        IEnumerable<NeighborhoodAssociationDTO> GetNeighborhoodAssociations();
        NeighborhoodAssociationDTO GetNeighborhoodAssociation(int neighborhoodAssociationID);
        void Create(NeighborhoodAssociationFormObject formObject);
        void Update(NeighborhoodAssociationFormObject formObject);
        void Delete(int neighborhoodAssociationID);
    }
}