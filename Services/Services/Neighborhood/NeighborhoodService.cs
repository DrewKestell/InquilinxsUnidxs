using DataAccess.Context;
using DataAccess.FormObject;
using DataAccess.Model;
using Services.DTO;
using System;
using System.Linq;

namespace Services
{
    public class NeighborhoodService : INeighborhoodService
    {
        readonly IGenericRepository<Neighborhood> neighborhoodRepository;
        readonly IUnitOfWork unitOfWork;

        public NeighborhoodService(IGenericRepository<Neighborhood> neighborhoodRepository, IUnitOfWork unitOfWork)
        {
            this.neighborhoodRepository = neighborhoodRepository;
            this.unitOfWork = unitOfWork;
        }

        public PaginationDTO<NeighborhoodDTO> GetNeighborhoods(int page, int pageSize)
        {
            var model = neighborhoodRepository
                .Get(n => n.Buildings.Select(b => b.State))
                .OrderBy(n => n.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList()
                .Select(n => new NeighborhoodDTO(n));

            var totalRecords = neighborhoodRepository.Get().Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize); // FIXME: this feels ugly

            return new PaginationDTO<NeighborhoodDTO>(model, totalRecords, totalPages);
        }

        public NeighborhoodDTO GetNeighborhood(int neighborhoodID) =>
            new NeighborhoodDTO(neighborhoodRepository
                .Get(n => n.Buildings.Select(b => b.State))
                .Single(r => r.ID == neighborhoodID));

        // TODO: share code with Update
        public void Create(NeighborhoodFormObject formObject)
        {
            neighborhoodRepository.Add(new Neighborhood
            {
                Name = formObject.Name
            });
            unitOfWork.Save();
        }

        // TODO: share code with Create
        public void Update(NeighborhoodFormObject formObject)
        {
            var neighborhood = neighborhoodRepository.Single(n => n.ID == formObject.ID);
            neighborhood.Name = formObject.Name;
            unitOfWork.Save();
        }

        public void Delete(int neighborhoodID)
        {
            var neighborhood = neighborhoodRepository.Single(r => r.ID == neighborhoodID);
            neighborhoodRepository.Remove(neighborhood);
            unitOfWork.Save();
        }
    }
}