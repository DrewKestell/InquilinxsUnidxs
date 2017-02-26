using Services;
using System.Collections.Generic;
using System.Linq;
using UseCases.Presenters;

namespace UseCases
{
    public class GetNeighborhoodAssociations : IGetNeighborhoodAssociations
    {
        readonly INeighborhoodAssociationService neighborhoodAssociationService;

        public GetNeighborhoodAssociations(INeighborhoodAssociationService neighborhoodAssociationService)
        {
            this.neighborhoodAssociationService = neighborhoodAssociationService;
        }

        public IEnumerable<NeighborhoodAssociationPresenter> Execute() =>
            neighborhoodAssociationService.GetNeighborhoodAssociations().Select(a => new NeighborhoodAssociationPresenter(a));
    }
}