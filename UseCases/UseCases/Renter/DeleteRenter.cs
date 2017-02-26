using Services;

namespace UseCases
{
    public class DeleteRenter : IDeleteRenter
    {
        readonly IRenterService renterService;

        public DeleteRenter(IRenterService renterService)
        {
            this.renterService = renterService;
        }

        public void Execute(int renterID) => renterService.Delete(renterID);
    }
}