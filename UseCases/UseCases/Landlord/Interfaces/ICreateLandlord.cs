using DataAccess.FormObject;

namespace UseCases
{
    public interface ICreateLandlord
    {
        void Execute(LandlordFormObject formObject);
    }
}