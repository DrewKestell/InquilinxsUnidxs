using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Renter
    {
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int AddressID { get; set; }

        public virtual Address Address { get; set; }
    }
}