using DataAccess.FormObject;
using InquilinxsUnidxs.Presenters;
using System.Linq;

namespace InquilinxsUnidxs.Services
{
    public class RenterService : DataAccess.Service.RenterService
    {
        public RenterPresenter GetNewRenterPresenter()
        {
            return new RenterPresenter(base.GetBuildings());
        }

        public PaginationPresenter<RenterPresenter> GetRenterPresenters(int page, int pageSize)
        {
            var dto = base.GetRenters(page, pageSize);
            var buildings = base.GetBuildings();
            var model = dto.Model.Select(r => new RenterPresenter(r, buildings)).ToList();
            return new PaginationPresenter<RenterPresenter>(model, page, pageSize, dto.TotalRecords, dto.TotalPages);
        }

        public RenterPresenter GetRenterPresenter(int renterID)
        {
            return new RenterPresenter(base.GetRenter(renterID), base.GetBuildings());
        }

        public new void Create(RenterFormObject formObject)
        {
            base.Create(formObject);
        }

        public new void Update(RenterFormObject formObject)
        {
            base.Update(formObject);
        }

        public new void Delete(int renterID)
        {
            base.Delete(renterID);
        }
    }
}