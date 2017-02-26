using DataAccess.FormObject;
using Services;

namespace UseCases
{
    public class UpdateRenter : IUpdateRenter
    {
        readonly IRenterService renterService;

        public UpdateRenter(IRenterService renterService)
        {
            this.renterService = renterService;
        }

        public void Execute(RenterFormObject formObject) => renterService.Update(formObject);
    }
}