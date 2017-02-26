using DataAccess.CustomConventions;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Renter : IEntity<int>
    {
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        public int ResidenceID { get; set; }

        [CascadeDelete]
        public virtual Residence Residence { get; set; }

        public string Name
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        } 
    }
}