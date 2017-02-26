using DataAccess.FormObject;

namespace UseCases
{
    public interface ICreatePropertyManagementCompany
    {
        void Execute(PropertyManagementCompanyFormObject formObject, int userID);
    }
}