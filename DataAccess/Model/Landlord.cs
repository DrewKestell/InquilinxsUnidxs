using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Landlord
    {
        public Landlord()
        {
            Buildings = new HashSet<Building>();
        }

        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }

        public ICollection<Building> Buildings { get; set; }
    }
}