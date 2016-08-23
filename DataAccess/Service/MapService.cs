using DataAccess.FormObject;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Service
{
    public class MapService : Service
    {
        protected List<Neighborhood> GetNeighborhoods()
        {
            using (var context = this.GetApplicationContext())
            {
                return context.Neighborhoods
                    .OrderBy(n => n.Name)
                    .ToList();
            }
        }

        protected List<Landlord> GetLandlords()
        {
            using (var context = this.GetApplicationContext())
            {
                return context.Landlords
                    .OrderBy(l => l.LastName)
                    .ThenBy(l => l.FirstName)
                    .ToList();
            }
        }

        protected List<Building> GetBuildings(int? neighborhoodID, int? landlordID, string filter)
        {
            using (var context = this.GetApplicationContext())
            {
                var buildings = context.Buildings
                    .Include("State")
                    .Include("Landlord")
                    .Include("Neighborhood")
                    .Include("Residences.Renters")
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

                return buildings.ToList();
            }
        }

        public void UpdateGeolocation(List<MapBuildingFormObject> formObjects)
        {
            using (var context = this.GetApplicationContext())
            {
                foreach (var building in formObjects)
                {
                    var buildingToUpdate = context.Buildings.Single(b => b.ID == building.ID);
                    buildingToUpdate.Latitude = building.Latitude;
                    buildingToUpdate.Longitude = building.Longitude;
                }                
                context.SaveChanges();
            }
        }
    }
}