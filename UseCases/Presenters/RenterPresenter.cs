using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UseCases.Presenters
{
    public class RenterPresenter
    {
        public string Address { get; }
        public IEnumerable<Tuple<int, string, IEnumerable<Tuple<int, string>>>> AllBuildings { get; }
        public int BuildingID { get; }
        public int ID { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string PhoneNumber { get; }
        public int ResidenceID { get; }
        public string ResidenceName { get; }

        public RenterPresenter(IEnumerable<BuildingDTO> allBuildings)
        {
            AllBuildings = allBuildings.Select(b => Tuple.Create(b.ID, b.FullAddress, b.Residences.Select(r => Tuple.Create(r.ID, r.Name))));
        }

        public RenterPresenter(RenterDTO renter, IEnumerable<BuildingDTO> allBuildings) : this(allBuildings)
        {
            ID = renter.ID;
            FirstName = renter.FirstName;
            LastName = renter.LastName;
            PhoneNumber = renter.PhoneNumber;
            BuildingID = renter.Residence.Building.ID;
            ResidenceID = renter.Residence.ID;
            ResidenceName = renter.Residence.Name;
            Address = renter.Residence.Building.FullAddress;
        }
    }
}