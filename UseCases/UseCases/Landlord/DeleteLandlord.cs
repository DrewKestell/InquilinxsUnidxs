using Services;

namespace UseCases
{
    public class DeleteLandlord : IDeleteLandlord
    {
        readonly ILandlordService landlordService;

        public DeleteLandlord(ILandlordService landlordService)
        {
            this.landlordService = landlordService;
        }

        public void Execute(int landlordID) => landlordService.Delete(landlordID);
    }
}