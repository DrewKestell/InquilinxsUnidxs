using DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace Services.DTO
{
    public class PropertyManagementCompanyDTO
    {
        public int ID { get; }
        public string Name { get; }
        public string Address { get; }
        public string City { get; }
        public StateDTO State { get; }
        public string ZIP { get; }
        public IEnumerable<CommentDTO> Comments { get; }
        public IEnumerable<SuperTuple<int>> Landlords { get; }

        public PropertyManagementCompanyDTO(PropertyManagementCompany company)
        {
            ID = company.ID;
            Name = company.Name;
            Address = company.Address;
            City = company.City;
            State = new StateDTO(company.State);
            ZIP = company.ZIP;
            Comments = company.Comments.Select(c => new PropertyManagementCompanyCommentDTO(c));
            Landlords = company.Landlords.Select(l => SuperTuple.Create(l.ID, l.Name));
        }
    }
}