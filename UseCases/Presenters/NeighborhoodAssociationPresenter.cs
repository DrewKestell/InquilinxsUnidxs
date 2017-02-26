using Services.DTO;

namespace UseCases.Presenters
{
    public class NeighborhoodAssociationPresenter
    {
        public int ID { get; }
        public string Name { get; }
        public string ContactFirstName { get; }
        public string ContactLastName { get; }
        public string ContactTitle { get; }
        public string ContactPhoneNumber { get; }

        public NeighborhoodAssociationPresenter() { }

        public NeighborhoodAssociationPresenter(NeighborhoodAssociationDTO neighborhoodAssociation)
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