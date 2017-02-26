using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class NeighborhoodAssociation : IEntity<int>
    {
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string ContactFirstName { get; set; }

        [MaxLength(100)]
        public string ContactLastName { get; set; }

        [MaxLength(100)]
        public string ContactTitle { get; set; }

        [MaxLength(10)]
        public string ContactPhoneNumber { get; set; }
    }
}
