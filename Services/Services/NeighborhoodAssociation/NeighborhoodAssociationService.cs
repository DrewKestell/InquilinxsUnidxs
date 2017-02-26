using DataAccess.Context;
using DataAccess.FormObject;
using DataAccess.Model;
using Services.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class NeighborhoodAssociationService : INeighborhoodAssociationService
    {
        readonly IGenericRepository<NeighborhoodAssociation> neighborhoodAssociationRepository;
        readonly IUnitOfWork unitOfWork;

        public NeighborhoodAssociationService(IGenericRepository<NeighborhoodAssociation> neighborhoodAssociationRepository,
           IUnitOfWork unitOfWork)
        {
            this.neighborhoodAssociationRepository = neighborhoodAssociationRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<NeighborhoodAssociationDTO> GetNeighborhoodAssociations() =>
            neighborhoodAssociationRepository.Get().ToList().Select(a => new NeighborhoodAssociationDTO(a));

        public NeighborhoodAssociationDTO GetNeighborhoodAssociation(int neighborhoodAssociationID) =>
            new NeighborhoodAssociationDTO(neighborhoodAssociationRepository.Single(r => r.ID == neighborhoodAssociationID));

        // TODO: share code with Update
        public void Create(NeighborhoodAssociationFormObject formObject)
        {
            var newNeighborhoodAssociation = new NeighborhoodAssociation
            {
                Name = formObject.Name,
                ContactFirstName = formObject.ContactFirstName,
                ContactLastName = formObject.ContactLastName,
                ContactTitle = formObject.ContactTitle,
                ContactPhoneNumber = formObject.ContactPhoneNumber
            };
            neighborhoodAssociationRepository.Add(newNeighborhoodAssociation);

            unitOfWork.Save();
        }

        // TODO: share code with Create
        public void Update(NeighborhoodAssociationFormObject formObject)
        {
            var neighborhoodAssociation = neighborhoodAssociationRepository.Single(r => r.ID == formObject.ID);
            neighborhoodAssociation.Name = formObject.Name;
            neighborhoodAssociation.ContactFirstName = formObject.ContactFirstName;
            neighborhoodAssociation.ContactLastName = formObject.ContactLastName;
            neighborhoodAssociation.ContactTitle = formObject.ContactTitle;
            neighborhoodAssociation.ContactPhoneNumber = formObject.ContactPhoneNumber;

            unitOfWork.Save();
        }

        public void Delete(int neighborhoodAssociationID)
        {
            neighborhoodAssociationRepository.Remove(neighborhoodAssociationRepository.Single(r => r.ID == neighborhoodAssociationID));
            unitOfWork.Save();
        }
    }
}