using DataAccess.FormObjects;
using InquilinxsUnidxs.Presenters;
using System.Collections.Generic;
using System.Linq;

namespace InquilinxsUnidxs.Services.Renter
{
    public class RenterService : DataAccess.Services.RenterService
    {
        public RenterPresenter GetNewRenterPresenter()
        {
            return new RenterPresenter();
        }

        public List<RenterPresenter> GetRenterPresenters()
        {
            return this.GetRenters().Select(r => new RenterPresenter(r)).ToList();
        }

        public RenterPresenter GetRenterPresenter(int renterID)
        {
            return new RenterPresenter(this.GetRenter(renterID));
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