using CsvHelper;
using DataAccess.Context;
using DataAccess.FormObject;
using DataAccess.Model;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Services
{
    public class RenterService : IRenterService
    {
        readonly IGenericRepository<Renter> renterRepository;
        readonly IGenericRepository<Building> buildingRepository;
        readonly IUnitOfWork unitOfWork;

        public RenterService(IGenericRepository<Renter> renterRepository, IGenericRepository<Building> buildingRepository, 
            IUnitOfWork unitOfWork)
        {
            this.renterRepository = renterRepository;
            this.buildingRepository = buildingRepository;
            this.unitOfWork = unitOfWork;
        }

        public PaginationDTO<RenterDTO> GetRenters(int page, int pageSize, string filter)
        {
            var query = renterRepository
                .Get(r => r.Residence.Building.State)
                .Where(r => r.FirstName.Contains(filter) || r.LastName.Contains(filter));

            var totalRecords = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize); // FIXME: this feels ugly

            var model = query
                .OrderBy(r => r.LastName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList()
                .Select(r => new RenterDTO(r));

            return new PaginationDTO<RenterDTO>(model, totalRecords, totalPages);
        }

        public IEnumerable<BuildingDTO> GetBuildings() =>
            buildingRepository
                .Get(b => b.State, b => b.Residences)
                .ToList()
                .Select(b => new BuildingDTO(b));

        public RenterDTO GetRenter(int renterID) =>
            new RenterDTO(renterRepository
                .Get(r => r.Residence.Building.State)
                .Single(r => r.ID == renterID));

        // TODO: share code with Update
        public void Create(RenterFormObject formObject)
        {
            renterRepository.Add(new Renter
            {
                FirstName = formObject.FirstName,
                LastName = formObject.LastName,
                PhoneNumber = formObject.PhoneNumber,
                ResidenceID = formObject.ResidenceID
            });
            unitOfWork.Save();
        }

        // TODO: share code with Create
        public void Update(RenterFormObject formObject)
        {
            var renter = renterRepository.Single(r => r.ID == formObject.ID);
            renter.FirstName = formObject.FirstName;
            renter.LastName = formObject.LastName;
            renter.PhoneNumber = formObject.PhoneNumber;
            unitOfWork.Save();
        }

        public void Delete(int renterID)
        {
            renterRepository.Remove(renterRepository.Single(r => r.ID == renterID));
            unitOfWork.Save();
        }

        public string GetRenterExport()
        {
            var sw = new StringWriter();
            var csv = new CsvWriter(sw);

            csv.WriteField("First Name");
            csv.WriteField("Last Name");
            csv.WriteField("Phone Number");
            csv.WriteField("Address");
            csv.WriteField("City");
            csv.WriteField("State");
            csv.WriteField("ZIP");
            csv.WriteField("Residence");

            csv.NextRecord();

            foreach (var renter in renterRepository.Get(r => r.Residence.Building.State).ToList())
            {
                csv.WriteField(renter.FirstName);
                csv.WriteField(renter.LastName);
                csv.WriteField(renter.PhoneNumber);
                csv.WriteField(renter.Residence.Building.Address);
                csv.WriteField(renter.Residence.Building.City);
                csv.WriteField(renter.Residence.Building.State.Abbreviation);
                csv.WriteField(renter.Residence.Building.ZIP);
                csv.WriteField(renter.Residence.Name);

                csv.NextRecord();
            }

            return sw.ToString();
        }
    }
}