using DataAccess.Model;

namespace Services.DTO
{
    public class RenterDTO
    {
        public int ID { get; }
        public string FirstName { get; }
        public string FullName { get; }
        public string LastName { get; }
        public string PhoneNumber { get; }
        public ResidenceDTO Residence { get; }

        public RenterDTO(Renter renter)
        {
            ID = renter.ID;
            FirstName = renter.FirstName;
            FullName = $"{renter.FirstName} {renter.LastName}";
            LastName = renter.LastName;
            PhoneNumber = renter.PhoneNumber;
            Residence = new ResidenceDTO(renter.Residence);
        }
    }
}