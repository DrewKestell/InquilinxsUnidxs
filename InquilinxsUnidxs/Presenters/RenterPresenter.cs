using DataAccess.Models;

namespace InquilinxsUnidxs.Presenters
{
    public class RenterPresenter
    {
        public int ID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public RenterPresenter() { }

        public RenterPresenter(Renter renter)
        {
            ID = renter.ID;
            FirstName = renter.FirstName;
            LastName = renter.LastName;
        }
    }
}