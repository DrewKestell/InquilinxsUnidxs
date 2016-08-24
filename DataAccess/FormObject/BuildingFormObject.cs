using DataAccess.Enum;

namespace DataAccess.FormObject
{
    public class BuildingFormObject
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZIP { get; set; }
        public States StateID { get; set; }
        public int LandlordID { get; set; }
        public int NeighborhoodID { get; set; }
    }
}