using Services;
using Services.DTO;
using System.Collections.Generic;
using UseCases.Presenters;

namespace UseCases
{
    public class EditResidence : IEditResidence
    {
        readonly IResidenceService residenceService;
        readonly IEnumerable<SuperTuple<int>> allBuildings;

        public EditResidence(IResidenceService residenceService, ISuperTupleService superTupleService)
        {
            this.residenceService = residenceService;
            allBuildings = superTupleService.GetAll(c => c.Buildings);
        }

        public ResidencePresenter Execute(int residenceID) => new ResidencePresenter(residenceService.GetResidence(residenceID), allBuildings);
    }
}