using DataAccess.FormObject;

namespace UseCases
{
    public interface IUpdateResidence
    {
        void Execute(ResidenceFormObject formObject, int userID);
    }
}