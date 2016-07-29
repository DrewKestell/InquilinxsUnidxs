using DataAccess.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
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