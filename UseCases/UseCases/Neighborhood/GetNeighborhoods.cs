using Services;
using System.Linq;
using UseCases.Presenters;

namespace UseCases
{
    public class GetNeighborhoods : IGetNeighborhoods
    {
        readonly INeighborhoodService neighborhoodService;

        public GetNeighborhoods(INeighborhoodService neighborhoodService)
        {
            this.neighborhoodService = neighborhoodService;
        }

        public PaginationPresenter<NeighborhoodPresenter> Execute(int page, int pageSize)
        {
            var neighborhoods = neighborhoodService.GetNeighborhoods(page, pageSize);
            var model = neighborhoods.Model.Select(n => new NeighborhoodPresenter(n)).ToList();
            var paginationInfo = new PaginationInfo(page, pageSize, neighborhoods.TotalRecords, neighborhoods.TotalPages);
            return new PaginationPresenter<NeighborhoodPresenter>(model, paginationInfo);
        }
    }
}