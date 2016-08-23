using DataAccess.Model;

namespace InquilinxsUnidxs.Presenters
{
    public class LandlordPresenter
    {
        public int ID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public LandlordPresenter() { }

        public LandlordPresenter(Landlord landlord)
        {
            ID = landlord.ID;
            FirstName = landlord.FirstName;
            LastName = landlord.LastName;
        }
    }
}