using DataAccess.FormObject;
using Services;

namespace UseCases
{
    public class CreateResidence : ICreateResidence
    {
        readonly IResidenceService residenceService;

        public CreateResidence(IResidenceService residenceService)
        {
            this.residenceService = residenceService;
        }

        public void Execute(ResidenceFormObject formObject, int currentUserID) => 
            residenceService.Create(formObject, currentUserID);
    }
}