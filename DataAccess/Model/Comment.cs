using DataAccess.CustomConventions;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public abstract class Comment
    {
        public int ID { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }

        [Required, MaxLength(500)]
        public string Value { get; set; }

        public int CreatedByID { get; set; }

        public int LastUpdatedByID { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual User LastUpdatedBy { get; set; }
    }
}