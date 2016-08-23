using DataAccess.FormObject;
using InquilinxsUnidxs.Presenters;
using System.Linq;

namespace InquilinxsUnidxs.Services
{
    public class LandlordService : DataAccess.Service.LandlordService
    {
        public LandlordPresenter GetNewLandlordPresenter()
        {
            return new LandlordPresenter();
        }

        public PaginationPresenter<LandlordPresenter> GetLandlordPresenters(int page, int pageSize)
        {
            var dto = base.GetLandlords(page, pageSize);
            var model = dto.Model.Select(landlord => new LandlordPresenter(landlord)).ToList();
            return new PaginationPresenter<LandlordPresenter>(model, page, pageSize, dto.TotalRecords, dto.TotalPages);
        }

        public LandlordPresenter GetLandlordPresenter(int landlordID)
        {
            return new LandlordPresenter(base.GetLandlord(landlordID));
        }

        public new void Create(LandlordFormObject formObject)
        {
            base.Create(formObject);
        }

        public new void Update(LandlordFormObject formObject)
        {
            base.Update(formObject);
        }

        public new void Delete(int landlordID)
        {
            base.Delete(landlordID);
        }
    }
}