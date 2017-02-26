using DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace Services.DTO
{
    public class BuildingDTO
    {
        public string Address { get; }
        public IEnumerable<BuildingCommentDTO> BuildingComments { get; }
        public string City { get; }
        public int ID { get; }
        public string FullAddress { get; }
        public LandlordDTO Landlord { get; }
        public double Latitude { get; }
        public double Longitude { get; }
        public NeighborhoodDTO Neighborhood { get; }
        public IEnumerable<ResidenceDTO> Residences { get; }
        public StateDTO State { get; }
        public string ZIP { get; }
        
        public BuildingDTO(Building building)
        {
            Address = building.Address;
            BuildingComments = building.BuildingComments.Select(bc => new BuildingCommentDTO(bc));
            City = building.City;            
            ID = building.ID;
            FullAddress = building.Name; // this is ghetto
            Landlord = new LandlordDTO(building.Landlord);
            Latitude = building.Latitude;
            Longitude = building.Longitude;
            Neighborhood = new NeighborhoodDTO(building.Neighborhood);
            Residences = building.Residences.Select(r => new ResidenceDTO(r));
            State = new StateDTO(building.State);
            ZIP = building.ZIP;
        }
    }
}