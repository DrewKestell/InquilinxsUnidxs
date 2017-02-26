using DataAccess.Enum;

namespace DataAccess.FormObject
{
    public class LandlordFormObject
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? PropertyManagementCompanyID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZIP { get; set; }
        public States StateID { get; set; }
    }
}