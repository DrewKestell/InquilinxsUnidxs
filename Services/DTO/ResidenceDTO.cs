using DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace Services.DTO
{
    public class ResidenceDTO
    {
        public int ID { get; }
        public string Name { get; }
        public BuildingDTO Building { get; }
        public IEnumerable<RenterDTO> Renters { get; }
        public IEnumerable<ResidenceCommentDTO> ResidenceComments { get; }

        public ResidenceDTO(Residence residence)
        {
            ID = residence.ID;
            Name = residence.Name;
            Building = new BuildingDTO(residence.Building);
            Renters = residence.Renters.Select(r => new RenterDTO(r));
            ResidenceComments = residence.ResidenceComments.Select(c => new ResidenceCommentDTO(c));
        }
    }
}