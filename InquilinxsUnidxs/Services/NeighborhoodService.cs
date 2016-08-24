using DataAccess.FormObject;
using InquilinxsUnidxs.Presenters;
using System.Linq;

namespace InquilinxsUnidxs.Services
{
    public class NeighborhoodService : DataAccess.Service.NeighborhoodService
    {
        public NeighborhoodPresenter GetNewNeighborhoodPresenter()
        {
            return new NeighborhoodPresenter();
        }

        public PaginationPresenter<NeighborhoodPresenter> GetNeighborhoodPresenters(int page, int pageSize)
        {
            var dto = base.GetNeighborhoods(page, pageSize);
            var model = dto.Model.Select(n => new NeighborhoodPresenter(n)).ToList();
            return new PaginationPresenter<NeighborhoodPresenter>(model, page, pageSize, dto.TotalRecords, dto.TotalPages);
        }

        public NeighborhoodPresenter GetNeighborhoodPresenter(int neighborhoodID)
        {
            return new NeighborhoodPresenter(base.GetNeighborhood(neighborhoodID));
        }

        public new void Create(NeighborhoodFormObject formObject)
        {
            base.Create(formObject);
        }

        public new void Update(NeighborhoodFormObject formObject)
        {
            base.Update(formObject);
        }

        public new void Delete(int neighborhoodID)
        {
            base.Delete(neighborhoodID);
        }
    }
}