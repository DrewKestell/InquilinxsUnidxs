using Services;
using Services.DTO;
using System.Collections.Generic;
using UseCases.Presenters;

namespace UseCases
{
    public class ViewResidence : IViewResidence
    {
        readonly IResidenceService residenceService;

        public ViewResidence(IResidenceService residenceService)
        {
            this.residenceService = residenceService;
        }

        public ResidencePresenter Execute(int residenceID) => new ResidencePresenter(residenceService.GetResidence(residenceID), 
            new List<SuperTuple<int>>());
    }
}