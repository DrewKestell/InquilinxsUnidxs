using Services;
using UseCases.Presenters;

namespace UseCases
{
    public class EditRenter : IEditRenter
    {
        readonly IRenterService renterService;

        public EditRenter(IRenterService renterService)
        {
            this.renterService = renterService;
        }

        public RenterPresenter Execute(int renterID) => 
            new RenterPresenter(renterService.GetRenter(renterID), renterService.GetBuildings());
    }
}