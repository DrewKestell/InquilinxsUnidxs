using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class ResidenceComment
    {
        public int ID { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastUpdatd { get; set; }

        [Required]
        public string Comment { get; set; }

        public int ResidenceID { get; set; }

        public int UserID { get; set; }

        public virtual Residence Residence { get; set; }

        public virtual User User { get; set; }
    }
}