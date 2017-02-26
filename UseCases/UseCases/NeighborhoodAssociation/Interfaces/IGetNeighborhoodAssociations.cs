using System.Collections.Generic;
using UseCases.Presenters;

namespace UseCases
{
    public interface IGetNeighborhoodAssociations
    {
        IEnumerable<NeighborhoodAssociationPresenter> Execute();
    }
}