using DataAccess.FormObject;
using DataAccess.Model;
using InquilinxsUnidxs.Presenters;
using System.Linq;

namespace InquilinxsUnidxs.Services
{
    public class BuildingService : DataAccess.Service.BuildingService
    {
        public BuildingPresenter GetNewBuildingPresenter()
        {
            return new BuildingPresenter(base.GetStates(), base.GetLandlords(), base.GetNeighborhoods());
        }

        public PaginationPresenter<BuildingPresenter> GetBuildingPresenters(int page, int pageSize)
        {
            var dto = base.GetBuildings(page, pageSize);
            var states = base.GetStates();
            var landlords = base.GetLandlords();
            var neighborhoods = base.GetNeighborhoods();
            var model = dto.Model.Select(m => new BuildingPresenter(m, states, landlords, neighborhoods)).ToList();
            return new PaginationPresenter<BuildingPresenter>(model, page, pageSize, dto.TotalRecords, dto.TotalPages);
        }

        public BuildingPresenter GetBuildingPresenter(int buildingID)
        {
            return new BuildingPresenter(base.GetBuilding(buildingID), base.GetStates(), base.GetLandlords(), base.GetNeighborhoods());
        }

        public new void Create(BuildingFormObject formObject, User currentUser)
        {
            base.Create(formObject, currentUser);
        }

        public new void Update(BuildingFormObject formObject, User currentUser)
        {
            base.Update(formObject, currentUser);
        }

        public new void Delete(int buildingID)
        {
            base.Delete(buildingID);
        }
    }
}