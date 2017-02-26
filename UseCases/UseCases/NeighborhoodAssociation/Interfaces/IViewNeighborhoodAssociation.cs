using UseCases.Presenters;

namespace UseCases
{
    public interface IViewNeighborhoodAssociation
    {
        NeighborhoodAssociationPresenter Execute(int neighborhoodAssociationID);
    }
}