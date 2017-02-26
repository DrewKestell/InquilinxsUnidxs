using DataAccess.FormObject;
using Services;

namespace UseCases
{
    public class UpdatePropertyManagementCompany : IUpdatePropertyManagementCompany
    {
        readonly IPropertyManagementCompanyService propertyManagementCompanyService;

        public UpdatePropertyManagementCompany(IPropertyManagementCompanyService propertyManagementCompanyService)
        {
            this.propertyManagementCompanyService = propertyManagementCompanyService;
        }

        public void Execute(PropertyManagementCompanyFormObject formObject, int userID) =>
            propertyManagementCompanyService.Update(formObject, userID);
    }
}