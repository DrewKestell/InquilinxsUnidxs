using DataAccess.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Landlord : IEntity<int>
    {
        public Landlord()
        {
            Buildings = new HashSet<Building>();
        }

        public int ID { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MinLength(5), MaxLength(5)]
        public string ZIP { get; set; }

        public States? StateID { get; set; }

        public virtual State State { get; set; }

        public int? PropertyManagementCompanyID { get; set; }

        public virtual PropertyManagementCompany PropertyManagementCompany { get; set; }

        public ICollection<Building> Buildings { get; set; }

        public string Name
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}