using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Residence
    {
        public Residence()
        {
            Renters = new HashSet<Renter>();
        }

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public int BuildingID { get; set; }

        public virtual Building Building { get; set; }

        public virtual ICollection<Renter> Renters { get; set; }
    }
}