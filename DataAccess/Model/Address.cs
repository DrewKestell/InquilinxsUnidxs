using DataAccess.Enum;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Address
    {
        public int ID { get; set; }

        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required]
        public string City { get; set; }

        [MinLength(5), MaxLength(5)]
        public string ZIP { get; set; }

        public States StateID { get; set; }

        public virtual State State { get; set; }     
    }
}