using DataAccess.FormObject;
using Services.DTO;
using System.Collections.Generic;

namespace Services
{
    public interface IPropertyManagementCompanyService
    {
        IEnumerable<PropertyManagementCompanyDTO> GetPropertyManagementCompanies();
        PropertyManagementCompanyDTO GetPropertyManagementCompany(int propertyManagementCompanyID);
        void Create(PropertyManagementCompanyFormObject formObject, int userID);
        void Update(PropertyManagementCompanyFormObject formObject, int userID);
        void Delete(int propertyManagementCompanyID);
    }
}