using DataAccess.FormObject;

namespace UseCases
{
    public interface IUpdateBuilding
    {
        void Execute(BuildingFormObject formObject, int userID);
    }
}