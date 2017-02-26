namespace UseCases
{
    public interface IPropertyManagementCompanyUseCases
    {
        ICreatePropertyManagementCompany CreatePropertyManagementCompany { get; }
        IDeletePropertyManagementCompany DeletePropertyManagementCompany { get; }
        IEditPropertyManagementCompany EditPropertyManagementCompany { get; }
        IGetPropertyManagementCompanies GetPropertyManagementCompanies { get; }
        INewPropertyManagementCompany NewPropertyManagementCompany { get; }
        IViewPropertyManagementCompany ViewPropertyManagementCompany { get; }
        IUpdatePropertyManagementCompany UpdatePropertyManagementCompany { get; }
    }
}