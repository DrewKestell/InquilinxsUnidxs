using DataAccess.FormObject;
using Services;

namespace UseCases
{
    public class UpdateLandlord : IUpdateLandlord
    {
        readonly ILandlordService landlordService;

        public UpdateLandlord(ILandlordService landlordService)
        {
            this.landlordService = landlordService;
        }

        public void Execute(LandlordFormObject formObject) => landlordService.Update(formObject);
    }
}