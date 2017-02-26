using DataAccess.Enum;
using Services;
using Services.DTO;
using System.Collections.Generic;
using UseCases.Presenters;

namespace UseCases
{
    public class EditPropertyManagementCompany : IEditPropertyManagementCompany
    {
        readonly IPropertyManagementCompanyService propertyManagementCompanyService;
        readonly IEnumerable<SuperTuple<States>> allStates;

        public EditPropertyManagementCompany(IPropertyManagementCompanyService propertyManagementCompanyService,
            ISuperTupleService superTupleService)
        {
            this.propertyManagementCompanyService = propertyManagementCompanyService;
            allStates = superTupleService.GetAll(c => c.States);
        }

        public PropertyManagementCompanyPresenter Execute(int companyID) =>
            new PropertyManagementCompanyPresenter(propertyManagementCompanyService.GetPropertyManagementCompany(companyID), allStates);
    }
}