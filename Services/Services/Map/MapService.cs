using DataAccess.Context;
using DataAccess.FormObject;
using DataAccess.Model;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class MapService : IMapService
    {
        readonly IGenericRepository<Building> buildingRepository;
        readonly IUnitOfWork unitOfWork;

        public MapService(IGenericRepository<Building> buildingRepository, IUnitOfWork unitOfWork)
        {
            this.buildingRepository = buildingRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<BuildingDTO> GetBuildings(int? neighborhoodID, int? landlordID, string filter)
        {
            var buildings = buildingRepository
                .Get(b => b.State, b => b.Landlord, b => b.Neighborhood, b => b.Residences.Select(r => r.Renters))
                    .AsQueryable();

            if (neighborhoodID != null)
                buildings = buildings.Where(b => b.NeighborhoodID == neighborhoodID);

            if (landlordID != null)
                buildings = buildings.Where(b => b.LandlordID == landlordID);

            if (!String.IsNullOrWhiteSpace(filter))
                buildings = buildings.Where(b => b.Address.Contains(filter)
                    || b.City.Contains(filter)
                    || b.State.Abbreviation.Contains(filter)
                    || b.State.Name.Contains(filter));

            return buildings.ToList().Select(b => new BuildingDTO(b));
        }

        public void UpdateGeolocation(IEnumerable<MapBuildingFormObject> formObjects)
        {
            foreach (var building in formObjects)
            {
                var buildingToUpdate = buildingRepository.Single(b => b.ID == building.ID);
                buildingToUpdate.Latitude = building.Latitude;
                buildingToUpdate.Longitude = building.Longitude;
            }
            unitOfWork.Save();
        }
    }
}