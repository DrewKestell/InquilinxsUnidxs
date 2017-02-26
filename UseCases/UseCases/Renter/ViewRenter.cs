using Services;
using Services.DTO;
using System.Collections.Generic;
using UseCases.Presenters;

namespace UseCases
{
    public class ViewRenter : IViewRenter
    {
        readonly IRenterService renterService;

        public ViewRenter(IRenterService renterService)
        {
            this.renterService = renterService;
        }

        public RenterPresenter Execute(int renterID) => new RenterPresenter(renterService.GetRenter(renterID), new List<BuildingDTO>());
    }
}