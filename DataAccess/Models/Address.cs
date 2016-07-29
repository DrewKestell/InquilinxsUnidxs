using DataAccess.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
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