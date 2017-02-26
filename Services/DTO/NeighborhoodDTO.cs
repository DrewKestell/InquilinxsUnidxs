using DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace Services.DTO
{
    public class NeighborhoodDTO
    {
        public int ID { get; }
        public string Name { get; }
        public IEnumerable<BuildingDTO> Buildings { get; }

        public NeighborhoodDTO(Neighborhood neighborhood)
        {
            ID = neighborhood.ID;
            Name = neighborhood.Name;
            Buildings = neighborhood.Buildings.Select(b => new BuildingDTO(b));
        }
    }
}