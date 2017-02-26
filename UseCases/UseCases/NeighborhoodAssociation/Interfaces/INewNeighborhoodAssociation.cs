using UseCases.Presenters;

namespace UseCases
{
    public interface INewNeighborhoodAssociation
    {
        NeighborhoodAssociationPresenter Execute();
    }
}