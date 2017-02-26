using DataAccess.FormObject;
using Services;

namespace UseCases
{
    public class UpdateResidence : IUpdateResidence
    {
        readonly IResidenceService residenceService;

        public UpdateResidence(IResidenceService residenceService)
        {
            this.residenceService = residenceService;
        }

        public void Execute(ResidenceFormObject formObject, int userID) => residenceService.Update(formObject, userID);
    }
}