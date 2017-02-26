using DataAccess.FormObject;

namespace UseCases
{
    public interface ICreateNeighborhood
    {
        void Execute(NeighborhoodFormObject formObject);
    }
}