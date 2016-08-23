using DataAccess.DTO;
using DataAccess.FormObject;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Service
{
    public class BuildingService : Service
    {
        protected List<State> GetStates()
        {
            using (var context = this.GetApplicationContext())
            {
                return context.States.ToList();
            }
        }

        protected List<Landlord> GetLandlords()
        {
            using (var context = this.GetApplicationContext())
            {
                return context.Landlords.ToList();
            }
        }

        protected List<Neighborhood> GetNeighborhoods()
        {
            using (var context = this.GetApplicationContext())
            {
                return context.Neighborhoods.ToList();
            }
        }

        protected PaginationDTO<Building> GetBuildings(int page, int pageSize)
        {
            using (var context = this.GetApplicationContext())
            {
                var model = context.Buildings
                    .Include("State")
                    .Include("Landlord")
                    .Include("Neighborhood")
                    .Include("Residences")
                    .OrderBy(b => b.State.Name)
                    .ThenBy(b => b.City)
                    .ThenBy(b => b.Address)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var totalRecords = context.Buildings.Count();
                var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize); // FIXME: this feels ugly

                return new PaginationDTO<Building>(model, totalRecords, totalPages);
            }
        }

        protected Building GetBuilding(int buildingID)
        {
            using (var context = this.GetApplicationContext())
            {
                return context.Buildings
                    .Include("State")
                    .Include("Landlord")
                    .Include("Neighborhood")
                    .Include("Residences")
                    .Single(r => r.ID == buildingID);
            }
        }

        // TODO: share code with Update
        protected void Create(BuildingFormObject formObject)
        {
            using (var context = this.GetApplicationContext())
            {
                context.Buildings.Add(new Building
                {
                    Latitude = 0, // handled by Google Geocoding API on front end
                    Longitude = 0, // handled by Google Geocoding API on front end
                    Address = formObject.Address,
                    City = formObject.City,
                    ZIP = formObject.ZIP,
                    StateID = formObject.StateID,
                    LandlordID = formObject.LandlordID,
                    NeighborhoodID = formObject.NeighborhoodID
                });
                context.SaveChanges();
            }
        }

        // TODO: share code with Create
        protected void Update(BuildingFormObject formObject)
        {
            using (var context = this.GetApplicationContext())
            {
                var building = context.Buildings.Single(r => r.ID == formObject.ID);
                building.Address = formObject.Address;
                building.City = formObject.City;
                building.ZIP = formObject.ZIP;
                building.StateID = formObject.StateID;
                building.LandlordID = formObject.LandlordID;
                building.NeighborhoodID = formObject.NeighborhoodID;
                context.SaveChanges();
            }
        }

        protected void Delete(int buildingID)
        {
            using (var context = this.GetApplicationContext())
            {
                var building = context.Buildings.Single(r => r.ID == buildingID);
                context.Buildings.Remove(building);
                context.SaveChanges();
            }
        }
    }
}