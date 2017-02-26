using DataAccess.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class PropertyManagementCompany : IEntity<int>
    {
        public PropertyManagementCompany()
        {
            Landlords = new HashSet<Landlord>();
            Comments = new HashSet<PropertyManagementCompanyComment>();
        }

        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Address { get; set; }

        [Required, MaxLength(100)]
        public string City { get; set; }

        [MinLength(5), MaxLength(5)]
        public string ZIP { get; set; }

        public States StateID { get; set; }

        public virtual State State { get; set; }

        public virtual ICollection<Landlord> Landlords { get; set; }

        public virtual ICollection<PropertyManagementCompanyComment> Comments { get; set; }
    }
}