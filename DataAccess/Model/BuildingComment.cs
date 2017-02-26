using DataAccess.CustomConventions;

namespace DataAccess.Model
{
    public class BuildingComment : Comment
    {
        public int BuildingID { get; set; }

        [CascadeDelete]
        public virtual Building Building { get; set; }
    }
}