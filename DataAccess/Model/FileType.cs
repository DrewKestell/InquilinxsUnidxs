using DataAccess.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    public class FileType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public FileTypes ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}