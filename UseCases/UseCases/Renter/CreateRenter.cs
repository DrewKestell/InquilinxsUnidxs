using DataAccess.FormObject;
using Services;

namespace UseCases
{
    public class CreateRenter : ICreateRenter
    {
        readonly IRenterService renterService;

        public CreateRenter(IRenterService renterService)
        {
            this.renterService = renterService;
        }

        public void Execute(RenterFormObject formObject) => renterService.Create(formObject);
    }
}