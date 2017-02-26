using DataAccess.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    public class State : IEntity<States>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public States ID { get; set; }

        [Required, MaxLength(5)]
        public string Abbreviation { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}