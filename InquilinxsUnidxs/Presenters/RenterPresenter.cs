using DataAccess.Enum;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InquilinxsUnidxs.Presenters
{
    // these constructors can be improved. Factory pattern perhaps?
    public class RenterPresenter
    {
        public int ID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public AddressPresenter Address { get; private set; }

        public List<Tuple<States, string>> AllStates { get; private set; }

        public RenterPresenter(List<State> states)
        {
            Address = new AddressPresenter();
            AllStates = states.Select(s => Tuple.Create(s.ID, s.Abbreviation)).ToList();
        }

        public RenterPresenter(Renter renter)
        {
            ID = renter.ID;
            FirstName = renter.FirstName;
            LastName = renter.LastName;
            Address = new AddressPresenter(renter.Address);
        }

        public RenterPresenter(Renter renter, List<State> states) : this(renter)
        {            
            AllStates = states.Select(s => Tuple.Create(s.ID, s.Abbreviation)).ToList();            
        }

    }
}