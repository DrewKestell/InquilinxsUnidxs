using DataAccess.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Building
    {
        public Building()
        {
            Residences = new HashSet<Residence>();
        }

        public int ID { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [MinLength(5), MaxLength(5)]
        public string ZIP { get; set; }

        public States StateID { get; set; }

        public virtual State State { get; set; }

        public int LandlordID { get; set; }

        public int NeighborhoodID { get; set; }

        public virtual Landlord Landlord { get; set; }

        public virtual Neighborhood Neighborhood { get; set; }

        public virtual ICollection<Residence> Residences { get; set; }

        // extension methods
        public string FullAddress
        {
            get
            {
                return String.Format("{0}, {1} {2} {3}", Address, City, State.Abbreviation, ZIP);
            }
        }
    }
}