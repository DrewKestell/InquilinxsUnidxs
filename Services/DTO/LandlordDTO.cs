using DataAccess.Enum;
using DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace Services.DTO
{
    public class LandlordDTO
    {
        public int ID { get; }
        public string FirstName { get; }
        public string FullName { get; }
        public string LastName { get; }
        public int? PropertyManagementCompanyID { get; }
        public string PropertyManagementCompanyName { get; }
        public string StateAbbreviation { get; }
        public States? StateID { get; }
        public string StateName { get; }
        public string ZIP { get; }
        public string Address { get; }
        public string City { get; }

        public IEnumerable<BuildingDTO> Buildings { get; }

        public LandlordDTO(Landlord landlord)
        {
            ID = landlord.ID;
            FirstName = landlord.FirstName;
            FullName = landlord.Name;
            LastName = landlord.LastName;
            PropertyManagementCompanyID = landlord.PropertyManagementCompanyID;
            PropertyManagementCompanyName = landlord.PropertyManagementCompany?.Name;
            StateAbbreviation = landlord.State?.Abbreviation;
            StateID = landlord.StateID;
            ZIP = landlord.ZIP;
            Address = landlord.ZIP;
            City = landlord.City;
            Buildings = landlord.Buildings.Select(b => new BuildingDTO(b));
        }
    }
}