using DataAccess.CustomConventions;
using DataAccess.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Building : IEntity<int>
    {
        public Building()
        {
            BuildingComments = new HashSet<BuildingComment>();
            Residences = new HashSet<Residence>();
        }

        public int ID { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [Required, MaxLength(100)]
        public string Address { get; set; }

        [Required, MaxLength(100)]
        public string City { get; set; }

        [Required, MinLength(5), MaxLength(5)]
        public string ZIP { get; set; }

        public int LandlordID { get; set; }

        public int NeighborhoodID { get; set; }

        public States StateID { get; set; }

        [CascadeDelete]
        public virtual Landlord Landlord { get; set; }

        [CascadeDelete]
        public virtual Neighborhood Neighborhood { get; set; }

        [CascadeDelete]
        public virtual State State { get; set; }

        public virtual ICollection<BuildingComment> BuildingComments { get; set; }

        public virtual ICollection<Residence> Residences { get; set; }

        public string Name
        {
            get
            {
                return $"{Address}, {City} {State.Abbreviation} {ZIP}";
            }
        }
    }
}