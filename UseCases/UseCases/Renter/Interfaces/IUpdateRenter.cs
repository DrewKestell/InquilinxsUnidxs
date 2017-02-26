using DataAccess.FormObject;

namespace UseCases
{
    public interface IUpdateRenter
    {
        void Execute(RenterFormObject formObject);
    }
}