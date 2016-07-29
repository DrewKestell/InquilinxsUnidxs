using DataAccess.Enums;

namespace DataAccess.FormObjects
{
    public class RenterFormObject
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public States StateID { get; set; }
        public string ZIP { get; set; }
    }
}