using DataAccess.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    public class State
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public States ID { get; set; }

        [Required]
        public string Abbreviation { get; set; }

        [Required]
        public string Name { get; set; }
    }
}