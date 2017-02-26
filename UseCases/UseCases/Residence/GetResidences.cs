using Services;
using Services.DTO;
using System.Collections.Generic;
using System.Linq;
using UseCases.Presenters;

namespace UseCases
{
    public class GetResidences : IGetResidences
    {
        readonly IResidenceService residenceService;
        readonly IEnumerable<SuperTuple<int>> allBuildings;

        public GetResidences(IResidenceService residenceService, ISuperTupleService superTupleService)
        {
            this.residenceService = residenceService;
            allBuildings = superTupleService.GetAll(c => c.Buildings);
        }

        public PaginationPresenter<ResidencePresenter> Execute(int page, int pageSize)
        {
            var residences = residenceService.GetResidences(page, pageSize);
            var model = residences.Model.Select(r => new ResidencePresenter(r, allBuildings)).ToList();
            var paginationInfo = new PaginationInfo(page, pageSize, residences.TotalRecords, residences.TotalPages);
            return new PaginationPresenter<ResidencePresenter>(model, paginationInfo);
        }
    }
}