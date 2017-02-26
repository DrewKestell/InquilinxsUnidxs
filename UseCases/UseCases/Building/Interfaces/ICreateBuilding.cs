using DataAccess.FormObject;

namespace UseCases
{
    public interface ICreateBuilding
    {
        void Execute(BuildingFormObject formObject, int userID);
    }
}