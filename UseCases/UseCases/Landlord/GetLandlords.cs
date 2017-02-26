using DataAccess.Enum;
using Services;
using Services.DTO;
using System.Collections.Generic;
using System.Linq;
using UseCases.Presenters;

namespace UseCases
{
    public class GetLandlords : IGetLandlords
    {
        readonly ILandlordService landlordService;
        readonly IEnumerable<SuperTuple<States>> allStates;
        readonly IEnumerable<SuperTuple<int>> allPropertyManagementCompanies;

        public GetLandlords(ILandlordService landlordService, ISuperTupleService superTupleService)
        {
            this.landlordService = landlordService;
            allStates = superTupleService.GetAll(c => c.States);
            allPropertyManagementCompanies = superTupleService.GetAll(c => c.PropertyManagementCompanies);
        }

        public PaginationPresenter<LandlordPresenter> Execute(int page, int pageSize)
        {
            var landlords = landlordService.GetLandlords(page, pageSize);
            var presenters = landlords.Model.Select(landlord => new LandlordPresenter(landlord, allStates, allPropertyManagementCompanies)).ToList();
            var paginationInfo = new PaginationInfo(page, pageSize, landlords.TotalRecords, landlords.TotalPages);
            return new PaginationPresenter<LandlordPresenter>(presenters, paginationInfo);
        }
    }
}