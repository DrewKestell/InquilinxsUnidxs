using Services;

namespace UseCases
{
    public class GetRenterExport : IGetRenterExport
    {
        IRenterService renterService;

        public GetRenterExport(IRenterService renterService)
        {
            this.renterService = renterService;
        }

        public string Execute() => renterService.GetRenterExport();        
    }
}
