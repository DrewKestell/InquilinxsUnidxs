using DataAccess.FormObject;

namespace UseCases
{
    public interface ICreateResidence
    {
        void Execute(ResidenceFormObject formObject, int currentUserID);
    }
}