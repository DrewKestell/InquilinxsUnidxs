using Services;
using UseCases.Presenters;

namespace UseCases
{
    public class NewRenter : INewRenter
    {
        readonly IRenterService renterService;

        public NewRenter(IRenterService renterService)
        {
            this.renterService = renterService;
        }

        public RenterPresenter Execute() => new RenterPresenter(renterService.GetBuildings());
    }
}