using DataAccess.FormObject;

namespace UseCases
{
    public interface IUpdateNeighborhood
    {
        void Execute(NeighborhoodFormObject formObject);
    }
}