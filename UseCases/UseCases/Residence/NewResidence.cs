using Services;
using Services.DTO;
using System.Collections.Generic;
using UseCases.Presenters;

namespace UseCases
{
    public class NewResidence : INewResidence
    {
        readonly IResidenceService residenceService;
        readonly IEnumerable<SuperTuple<int>> allBuildings;

        public NewResidence(IResidenceService residenceService, ISuperTupleService superTupleService)
        {
            this.residenceService = residenceService;
            allBuildings = superTupleService.GetAll(c => c.Buildings);
        }

        public ResidencePresenter Execute() => new ResidencePresenter(allBuildings);
    }
}