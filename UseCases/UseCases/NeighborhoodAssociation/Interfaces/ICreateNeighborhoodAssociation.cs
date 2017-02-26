using DataAccess.FormObject;

namespace UseCases
{
    public interface ICreateNeighborhoodAssociation
    {
        void Execute(NeighborhoodAssociationFormObject formObject);
    }
}