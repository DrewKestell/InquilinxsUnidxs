using DataAccess.Context;
using DataAccess.FormObject;
using DataAccess.Model;
using Services.DTO;
using System;
using System.Linq;

namespace Services
{
    public class LandlordService : ILandlordService
    {
        readonly IGenericRepository<Landlord> landlordRepository;
        readonly IUnitOfWork unitOfWork;

        public LandlordService(IGenericRepository<Landlord> landlordRepository, IUnitOfWork unitOfWork)
        {
            this.landlordRepository = landlordRepository;
            this.unitOfWork = unitOfWork;
        }

        public PaginationDTO<LandlordDTO> GetLandlords(int page, int pageSize)
        {
            var model = landlordRepository
                .Get(l => l.Buildings.Select(b => b.State), l => l.State)
                .OrderBy(l => l.LastName)
                .ThenBy(l => l.FirstName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList()
                .Select(l => new LandlordDTO(l));

            var totalRecords = landlordRepository.Get().Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize); // FIXME: this feels ugly

            return new PaginationDTO<LandlordDTO>(model, totalRecords, totalPages);
        }

        public LandlordDTO GetLandlord(int landlordID) =>
            new LandlordDTO(landlordRepository
                .Get(l => l.Buildings.Select(b => b.State), l => l.State)
                .Single(r => r.ID == landlordID));

        // TODO: share code with Update
        public void Create(LandlordFormObject formObject)
        {
            landlordRepository.Add(new Landlord
            {
                FirstName = formObject.FirstName,
                LastName = formObject.LastName,
                PropertyManagementCompanyID = formObject.PropertyManagementCompanyID,
                Address = formObject.Address,
                City = formObject.City,
                StateID = formObject.StateID,
                ZIP = formObject.ZIP
            });
            unitOfWork.Save();
        }

        // TODO: share code with Create
        public void Update(LandlordFormObject formObject)
        {
            var landlord = landlordRepository.Single(r => r.ID == formObject.ID);
            landlord.FirstName = formObject.FirstName;
            landlord.LastName = formObject.LastName;
            landlord.PropertyManagementCompanyID = formObject.PropertyManagementCompanyID;
            landlord.Address = formObject.Address;
            landlord.City = formObject.City;
            landlord.StateID = formObject.StateID;
            landlord.ZIP = formObject.ZIP;
            unitOfWork.Save();
        }

        public void Delete(int landlordID)
        {
            landlordRepository.Remove(landlordRepository.Single(r => r.ID == landlordID));
            unitOfWork.Save();
        }
    }
}