using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InquilinxsUnidxs.Presenters
{
    public class LandlordPresenter
    {
        public int ID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public List<Tuple<string, int>> Buildings { get; private set; }

        public LandlordPresenter() { }

        public LandlordPresenter(Landlord landlord)
        {
            ID = landlord.ID;
            FirstName = landlord.FirstName;
            LastName = landlord.LastName;
            Buildings = landlord.Buildings.Select(b => Tuple.Create(b.FullAddress, b.ID)).ToList();
        }
    }
}