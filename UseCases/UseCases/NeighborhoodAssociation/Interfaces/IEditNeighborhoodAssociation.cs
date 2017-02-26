using UseCases.Presenters;

namespace UseCases
{
    public interface IEditNeighborhoodAssociation
    {
        NeighborhoodAssociationPresenter Execute(int neighborhoodAssociationID);
    }
}