using DataAccess.FormObject;
using InquilinxsUnidxs.Presenters;
using System.Linq;

namespace InquilinxsUnidxs.Services
{
    public class ResidenceService : DataAccess.Service.ResidenceService
    {
        public ResidencePresenter GetNewResidencePresenter()
        {
            return new ResidencePresenter(base.GetBuildings());
        }

        public PaginationPresenter<ResidencePresenter> GetResidencePresenters(int page, int pageSize)
        {
            var dto = base.GetResidences(page, pageSize);
            var buildings = base.GetBuildings();
            var model = dto.Model.Select(r => new ResidencePresenter(r, buildings)).ToList();
            return new PaginationPresenter<ResidencePresenter>(model, page, pageSize, dto.TotalRecords, dto.TotalPages);
        }

        public ResidencePresenter GetResidencePresenter(int residenceID)
        {
            return new ResidencePresenter(base.GetResidence(residenceID), base.GetBuildings());
        }

        public new void Create(ResidenceFormObject formObject)
        {
            base.Create(formObject);
        }

        public new void Update(ResidenceFormObject formObject)
        {
            base.Update(formObject);
        }

        public new void Delete(int residenceID)
        {
            base.Delete(residenceID);
        }
    }
}