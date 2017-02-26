using DataAccess.Enum;
using Services;
using Services.DTO;
using System.Collections.Generic;
using UseCases.Presenters;

namespace UseCases
{
    public class ViewPropertyManagementCompany : IViewPropertyManagementCompany
    {
        readonly IPropertyManagementCompanyService propertyManagementCompanyService;

        public ViewPropertyManagementCompany(IPropertyManagementCompanyService propertyManagementCompanyService)
        {
            this.propertyManagementCompanyService = propertyManagementCompanyService;
        }

        public PropertyManagementCompanyPresenter Execute(int companyID) => 
            new PropertyManagementCompanyPresenter(propertyManagementCompanyService.GetPropertyManagementCompany(companyID), new List<SuperTuple<States>>());
    }
}