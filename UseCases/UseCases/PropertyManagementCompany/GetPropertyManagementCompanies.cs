using DataAccess.Enum;
using Services;
using Services.DTO;
using System.Collections.Generic;
using System.Linq;
using UseCases.Presenters;

namespace UseCases
{
    public class GetPropertyManagementCompanies : IGetPropertyManagementCompanies
    {
        readonly IPropertyManagementCompanyService propertyManagementCompanyService;
        readonly IEnumerable<SuperTuple<States>> allStates;

        public GetPropertyManagementCompanies(IPropertyManagementCompanyService propertyManagementCompanyService,
            ISuperTupleService superTupleService)
        {
            this.propertyManagementCompanyService = propertyManagementCompanyService;
            allStates = superTupleService.GetAll(c => c.States);
        }

        public IEnumerable<PropertyManagementCompanyPresenter> Execute() =>
            propertyManagementCompanyService.GetPropertyManagementCompanies()
                .Select(c => new PropertyManagementCompanyPresenter(c, allStates));
    }
}