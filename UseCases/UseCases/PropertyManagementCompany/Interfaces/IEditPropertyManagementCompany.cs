using UseCases.Presenters;

namespace UseCases
{
    public interface IEditPropertyManagementCompany
    {
        PropertyManagementCompanyPresenter Execute(int companyID);
    }
}