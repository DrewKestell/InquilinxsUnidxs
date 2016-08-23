using DataAccess.DTO;
using DataAccess.FormObject;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Service
{
    public class RenterService : Service
    {
        protected List<Building> GetBuildings()
        {
            using (var context = this.GetApplicationContext())
            {
                return context.Buildings
                    .Include("State")
                    .Include("Residences")
                    .ToList();
            }
        }

        protected PaginationDTO<Renter> GetRenters(int page, int pageSize)
        {
            using (var context = this.GetApplicationContext())
            {
                var model = context.Renters
                    .Include("Residence.Building.State")
                    .OrderBy(r => r.LastName)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var totalRecords = context.Renters.Count();
                var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize); // FIXME: this feels ugly

                return new PaginationDTO<Renter>(model, totalRecords, totalPages);
            }
        }

        protected Renter GetRenter(int renterID)
        {
            using (var context = this.GetApplicationContext())
            {
                return context.Renters
                    .Include("Residence.Building.State")
                    .Single(r => r.ID == renterID);
            }
        }

        // TODO: share code with Update
        protected void Create(RenterFormObject formObject)
        {
            using (var context = this.GetApplicationContext())
            {
                context.Renters.Add(new Renter
                {
                    FirstName = formObject.FirstName,
                    LastName = formObject.LastName,
                     ResidenceID = formObject.ResidenceID
                });
                context.SaveChanges();
            }
        }

        // TODO: share code with Create
        protected void Update(RenterFormObject formObject)
        {
            using (var context = this.GetApplicationContext())
            {
                var renter = context.Renters.Single(r => r.ID == formObject.ID);
                renter.FirstName = formObject.FirstName;
                renter.LastName = formObject.LastName;
                context.SaveChanges();
            }
        }

        protected void Delete(int renterID)
        {
            using (var context = this.GetApplicationContext())
            {
                var renter = context.Renters.Single(r => r.ID == renterID);
                context.Renters.Remove(renter);
                context.SaveChanges();
            }
        }
    }
}