using DataAccess.Enum;
using Services.DTO;
using System.Collections.Generic;
using System.Linq;

namespace UseCases.Presenters
{
    public class PropertyManagementCompanyPresenter
    {
        public int ID { get; }
        public string Name { get; }
        public string Address { get; }
        public string City { get; }
        public string StateAbbreviation { get; }
        public States? StateID { get; }
        public string StateName { get; }
        public string ZIP { get; }
        public IEnumerable<SuperTuple<States>> AllStates { get; }
        public IEnumerable<CommentPresenter> Comments { get; }
        public IEnumerable<SuperTuple<int>> Landlords { get; }

        public PropertyManagementCompanyPresenter(IEnumerable<SuperTuple<States>> allStates)
        {
            AllStates = allStates;
        }

        public PropertyManagementCompanyPresenter(PropertyManagementCompanyDTO company, IEnumerable<SuperTuple<States>> allStates)
            : this(allStates)
        {
            ID = company.ID;
            Name = company.Name;
            Address = company.Address;
            City = company.City;
            StateAbbreviation = company.State.Abbreviation;
            StateID = company.State.ID;
            StateName = company.State.Name;
            ZIP = company.ZIP;
            Comments = company.Comments.OrderByDescending(c => c.LastUpdated).Select(c => new CommentPresenter(c)).ToList();
            Landlords = company.Landlords;
        }
    }
}