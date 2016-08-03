using DataAccess.Model;

namespace InquilinxsUnidxs.Presenters
{
    public class AddressPresenter
    {
        public int ID { get; private set; }
        public string Address1 { get; private set; }
        public string Address2 { get; private set; }
        public string City { get; private set; }
        public string ZIP { get; private set; }
        public StatePresenter State { get; private set; }

        public AddressPresenter()
        {
            State = new StatePresenter();
        }

        public AddressPresenter(Address address)
        {
            ID = address.ID;
            Address1 = address.Address1;
            Address2 = address.Address2;
            City = address.City;
            ZIP = address.ZIP;
            State = new StatePresenter(address.State);
        }
    }
}