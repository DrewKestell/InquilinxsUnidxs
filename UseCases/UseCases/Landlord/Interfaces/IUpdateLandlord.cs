using DataAccess.FormObject;

namespace UseCases
{
    public interface IUpdateLandlord
    {
        void Execute(LandlordFormObject formObject);
    }
}