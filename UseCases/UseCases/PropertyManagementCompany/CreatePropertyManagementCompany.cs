using DataAccess.FormObject;
using Services;

namespace UseCases
{
    public class CreatePropertyManagementCompany : ICreatePropertyManagementCompany
    {
        readonly IPropertyManagementCompanyService propertyManagementCompanyService;

        public CreatePropertyManagementCompany(IPropertyManagementCompanyService propertyManagementCompanyService)
        {
            this.propertyManagementCompanyService = propertyManagementCompanyService;
        }

        public void Execute(PropertyManagementCompanyFormObject formObject, int userID) =>
            propertyManagementCompanyService.Create(formObject, userID);
    }
}