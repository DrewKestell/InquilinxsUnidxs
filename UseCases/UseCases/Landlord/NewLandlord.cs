using DataAccess.Enum;
using Services;
using Services.DTO;
using System.Collections.Generic;
using UseCases.Presenters;

namespace UseCases
{
    public class NewLandlord : INewLandlord
    {
        readonly ILandlordService landlordService;
        readonly IEnumerable<SuperTuple<States>> allStates;
        readonly IEnumerable<SuperTuple<int>> allPropertyManagementCompanies;

        public NewLandlord(ILandlordService landlordService, ISuperTupleService superTupleService)
        {
            this.landlordService = landlordService;
            allStates = superTupleService.GetAll(c => c.States);
            allPropertyManagementCompanies = superTupleService.GetAll(c => c.PropertyManagementCompanies);
        }

        public LandlordPresenter Execute() => new LandlordPresenter(allStates, allPropertyManagementCompanies);
    }
}