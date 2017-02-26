using DataAccess.Model;

namespace Services.DTO
{
    public class NeighborhoodAssociationDTO
    {
        public int ID { get; }
        public string Name { get; }
        public string ContactFirstName { get; }
        public string ContactLastName { get; }
        public string ContactTitle { get; }
        public string ContactPhoneNumber { get; }

        public NeighborhoodAssociationDTO(NeighborhoodAssociation neighborhoodAssociation)
        {
            ID = neighborhoodAssociation.ID;
            Name = neighborhoodAssociation.Name;
            ContactFirstName = neighborhoodAssociation.ContactFirstName;
            ContactLastName = neighborhoodAssociation.ContactLastName;
            ContactTitle = neighborhoodAssociation.ContactTitle;
            ContactPhoneNumber = neighborhoodAssociation.ContactPhoneNumber;
        }
    }
}