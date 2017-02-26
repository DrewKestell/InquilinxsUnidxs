using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Neighborhood : IEntity<int>
    {
        public Neighborhood()
        {
            Buildings = new HashSet<Building>();
        }

        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Building> Buildings { get; set; }
    }
}