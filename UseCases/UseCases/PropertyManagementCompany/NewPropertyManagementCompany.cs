using DataAccess.Enum;
using Services;
using Services.DTO;
using System.Collections.Generic;
using UseCases.Presenters;

namespace UseCases
{
    public class NewPropertyManagementCompany : INewPropertyManagementCompany
    {
        readonly IPropertyManagementCompanyService propertyManagementCompanyService;
        readonly IEnumerable<SuperTuple<States>> allStates;

        public NewPropertyManagementCompany(IPropertyManagementCompanyService propertyManagementCompanyService,
            ISuperTupleService superTupleService)
        {
            this.propertyManagementCompanyService = propertyManagementCompanyService;
            allStates = superTupleService.GetAll(c => c.States);
        }

        public PropertyManagementCompanyPresenter Execute() => new PropertyManagementCompanyPresenter(allStates);
    }
}