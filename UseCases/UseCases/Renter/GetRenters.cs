using Services;
using System.Linq;
using UseCases.Presenters;

namespace UseCases
{
    public class GetRenters : IGetRenters
    {
        readonly IRenterService renterService;

        public GetRenters(IRenterService renterService)
        {
            this.renterService = renterService;
        }

        public RenterIndexPresenter Execute(int page, int pageSize, string filter)
        {
            var renters = renterService.GetRenters(page, pageSize, filter);
            var buildings = renterService.GetBuildings();
            var model = renters.Model.Select(r => new RenterPresenter(r, buildings)).ToList();
            var paginationInfo = new PaginationInfo(page, pageSize, renters.TotalRecords, renters.TotalPages);
            var paginationPresenter = new PaginationPresenter<RenterPresenter>(model, paginationInfo);
            return new RenterIndexPresenter(paginationPresenter, filter);
        }
    }
}