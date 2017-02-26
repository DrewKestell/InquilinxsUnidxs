using DataAccess.FormObject;

namespace UseCases
{
    public interface IUpdateNeighborhoodAssociation
    {
        void Execute(NeighborhoodAssociationFormObject formObject);
    }
}