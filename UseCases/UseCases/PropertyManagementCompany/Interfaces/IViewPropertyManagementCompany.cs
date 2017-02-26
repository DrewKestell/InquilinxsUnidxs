using UseCases.Presenters;

namespace UseCases
{
    public interface IViewPropertyManagementCompany
    {
        PropertyManagementCompanyPresenter Execute(int companyID);
    }
}