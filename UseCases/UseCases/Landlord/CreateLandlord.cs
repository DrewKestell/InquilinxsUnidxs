using DataAccess.FormObject;
using Services;

namespace UseCases
{
    public class CreateLandlord : ICreateLandlord
    {
        readonly ILandlordService landlordService;

        public CreateLandlord(ILandlordService landlordService)
        {
            this.landlordService = landlordService;
        }

        public void Execute(LandlordFormObject formObject) => landlordService.Create(formObject);
    }
}