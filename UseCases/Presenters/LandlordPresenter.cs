using DataAccess.Enum;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UseCases.Presenters
{
    public class LandlordPresenter
    {
        public IEnumerable<SuperTuple<States>> AllStates { get; }
        public IEnumerable<SuperTuple<int>> AllPropertyManagementCompanies { get; }
        public IEnumerable<Tuple<int, string>> Buildings { get; }
        public string City { get; }
        public int ID { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int? PropertyManagementCompanyID { get; }
        public string PropertyManagementCompanyName { get; }
        public string StateAbbreviation { get; }
        public States? StateID { get; }
        public string StateName { get; }
        public string ZIP { get; }
        public string Address { get; }

        public LandlordPresenter(IEnumerable<SuperTuple<States>> allStates, IEnumerable<SuperTuple<int>> allPropertyManagementCompanies)
        {
            AllStates = allStates;
            AllPropertyManagementCompanies = allPropertyManagementCompanies;
        }

        public LandlordPresenter(LandlordDTO landlord, IEnumerable<SuperTuple<States>> allStates, IEnumerable<SuperTuple<int>> allPropertyManagementCompanies) 
            : this(allStates, allPropertyManagementCompanies)
        {
            Buildings = landlord.Buildings.Select(b => Tuple.Create(b.ID, b.FullAddress));
            ID = landlord.ID;
            FirstName = landlord.FirstName;
            LastName = landlord.LastName;
            PropertyManagementCompanyID = landlord.PropertyManagementCompanyID;
            PropertyManagementCompanyName = landlord.PropertyManagementCompanyName;
            Address = landlord.Address;
            City = landlord.City;
            ZIP = landlord.ZIP;
            StateName = landlord.StateName;
            StateAbbreviation = landlord.StateAbbreviation;
            StateID = landlord.StateID;   
        }
    }
}