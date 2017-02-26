using DataAccess.CustomConventions;

namespace DataAccess.Model
{
    public class PropertyManagementCompanyComment : Comment
    {
        public int PropertyManagementCompanyID { get; set; }

        [CascadeDelete]
        public virtual PropertyManagementCompany PropertyManagementCompany { get; set; }
    }
}