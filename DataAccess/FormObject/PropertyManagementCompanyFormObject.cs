using DataAccess.Enum;
using System.Collections.Generic;

namespace DataAccess.FormObject
{
    public class PropertyManagementCompanyFormObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZIP { get; set; }
        public States StateID { get; set; }
        public IEnumerable<CommentFormObject> Comments { get; set; }

        public PropertyManagementCompanyFormObject()
        {
            Comments = new List<CommentFormObject>();
        }
    }
}