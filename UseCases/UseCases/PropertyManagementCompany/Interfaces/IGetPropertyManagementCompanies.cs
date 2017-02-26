using System.Collections.Generic;
using UseCases.Presenters;

namespace UseCases
{
    public interface IGetPropertyManagementCompanies
    {
        IEnumerable<PropertyManagementCompanyPresenter> Execute();
    }
}