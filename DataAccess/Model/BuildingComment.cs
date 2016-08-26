using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class BuildingComment
    {
        public int ID { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }

        [Required]
        public string Comment { get; set; }

        public int BuildingID { get; set; }

        public int UserID { get; set; }

        public virtual Building Building { get; set; }

        public virtual User User { get; set; }
    }
}