using DataAccess.FormObject;

namespace UseCases
{
    public interface ICreateRenter
    {
        void Execute(RenterFormObject formObject);
    }
}