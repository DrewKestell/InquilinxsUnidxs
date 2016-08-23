using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Renter
    {
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int ResidenceID { get; set; }

        public virtual Residence Residence { get; set; }

        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }
    }
}