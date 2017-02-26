namespace UseCases
{
    public class PropertyManagementCompanyUseCases : IPropertyManagementCompanyUseCases
    {
        public ICreatePropertyManagementCompany CreatePropertyManagementCompany { get; }
        public IDeletePropertyManagementCompany DeletePropertyManagementCompany { get; }
        public IEditPropertyManagementCompany EditPropertyManagementCompany { get; }
        public IGetPropertyManagementCompanies GetPropertyManagementCompanies { get; }
        public INewPropertyManagementCompany NewPropertyManagementCompany { get; }
        public IViewPropertyManagementCompany ViewPropertyManagementCompany { get; }
        public IUpdatePropertyManagementCompany UpdatePropertyManagementCompany { get; }

        public PropertyManagementCompanyUseCases(ICreatePropertyManagementCompany createPropertyManagementCompany, IDeletePropertyManagementCompany deletePropertyManagementCompany,
            IEditPropertyManagementCompany editPropertyManagementCompany, IGetPropertyManagementCompanies getPropertyManagementCompanies,
            INewPropertyManagementCompany newPropertyManagementCompany, IViewPropertyManagementCompany viewPropertyManagementCompany,
            IUpdatePropertyManagementCompany updatePropertyManagementCompany)
        {
            CreatePropertyManagementCompany = createPropertyManagementCompany;
            DeletePropertyManagementCompany = deletePropertyManagementCompany;
            EditPropertyManagementCompany = editPropertyManagementCompany;
            GetPropertyManagementCompanies = getPropertyManagementCompanies;
            NewPropertyManagementCompany = newPropertyManagementCompany;
            ViewPropertyManagementCompany = viewPropertyManagementCompany;
            UpdatePropertyManagementCompany = updatePropertyManagementCompany;
        }
    }
}