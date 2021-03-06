﻿using DataAccess.CustomConventions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Residence : IEntity<int>
    {
        public Residence()
        {
            Renters = new HashSet<Renter>();
            ResidenceComments = new HashSet<ResidenceComment>();
        }

        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public int BuildingID { get; set; }

        [CascadeDelete]
        public virtual Building Building { get; set; }

        public virtual ICollection<Renter> Renters { get; set; }

        public virtual ICollection<ResidenceComment> ResidenceComments { get; set; }
    }
}