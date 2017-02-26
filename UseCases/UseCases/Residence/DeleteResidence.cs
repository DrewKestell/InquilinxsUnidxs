using Services;

namespace UseCases
{
    public class DeleteResidence : IDeleteResidence
    {
        readonly IResidenceService residenceService;

        public DeleteResidence(IResidenceService residenceService)
        {
            this.residenceService = residenceService;
        }

        public void Execute(int residenceID) => residenceService.Delete(residenceID);
    }
}