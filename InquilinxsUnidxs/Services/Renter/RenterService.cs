using DataAccess.FormObjects;
using InquilinxsUnidxs.Presenters;
using System.Linq;

namespace InquilinxsUnidxs.Services.Renter
{
    public class RenterService : DataAccess.Services.RenterService
    {
        public RenterPresenter GetNewRenterPresenter()
        {
            using (var context = this.GetApplicationContext())
            {
                var states = context.States.ToList();
                return new RenterPresenter(states);
            }
        }

        public PaginationPresenter<RenterPresenter> GetRenterPresenters(int page, int pageSize)
        {
            var dto = base.GetRenters(page, pageSize);
            var model = dto.Model.Select(r => new RenterPresenter(r)).ToList();
            return new PaginationPresenter<RenterPresenter>(model, page, pageSize, dto.TotalRecords, dto.TotalPages);
        }

        public RenterPresenter GetRenterPresenter(int renterID)
        {
            return new RenterPresenter(base.GetRenter(renterID), base.GetStates());
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