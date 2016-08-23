using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Neighborhood
    {
        public Neighborhood()
        {
            Buildings = new HashSet<Building>();
        }

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Building> Buildings { get; set; }
    }
}