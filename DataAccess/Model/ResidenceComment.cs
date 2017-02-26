using DataAccess.CustomConventions;

namespace DataAccess.Model
{
    public class ResidenceComment : Comment
    {
        public int ResidenceID { get; set; }

        [CascadeDelete]
        public virtual Residence Residence { get; set; }
    }
}