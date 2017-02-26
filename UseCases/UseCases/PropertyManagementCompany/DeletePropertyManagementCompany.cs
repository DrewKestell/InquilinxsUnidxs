using Services;

namespace UseCases
{
    public class DeletePropertyManagementCompany : IDeletePropertyManagementCompany
    {
        readonly IPropertyManagementCompanyService propertyManagementCompanyService;

        public DeletePropertyManagementCompany(IPropertyManagementCompanyService propertyManagementCompanyService)
        {
            this.propertyManagementCompanyService = propertyManagementCompanyService;
        }

        public void Execute(int companyID) => propertyManagementCompanyService.Delete(companyID);
    }
}