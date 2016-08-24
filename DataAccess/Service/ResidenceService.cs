using DataAccess.DTO;
using DataAccess.FormObject;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Service
{
    public class ResidenceService : Service
    {
        protected List<Building> GetBuildings()
        {
            using (var context = this.GetApplicationContext())
            {
                return context.Buildings
                    .Include("State")
                    .ToList();
            }
        }

        protected PaginationDTO<Residence> GetResidences(int page, int pageSize)
        {
            using (var context = this.GetApplicationContext())
            {
                var model = context.Residences
                    .Include("Building.State")
                    .Include("Renters")
                    .OrderBy(r => r.Building.Address)
                    .ThenBy(r => r.Name)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var totalRecords = context.Residences.Count();
                var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize); // FIXME: this feels ugly

                return new PaginationDTO<Residence>(model, totalRecords, totalPages);
            }
        }

        protected Residence GetResidence(int residenceID)
        {
            using (var context = this.GetApplicationContext())
            {
                return context.Residences
                    .Include("Building.State")
                    .Include("Renters")
                    .Single(r => r.ID == residenceID);
            }
        }

        // TODO: share code with Update
        protected void Create(ResidenceFormObject formObject)
        {
            using (var context = this.GetApplicationContext())
            {
                context.Residences.Add(new Residence
                {
                    Name = formObject.Name,
                    BuildingID = formObject.BuildingID
                });
                context.SaveChanges();
            }
        }

        // TODO: share code with Create
        protected void Update(ResidenceFormObject formObject)
        {
            using (var context = this.GetApplicationContext())
            {
                var residence = context.Residences.Single(r => r.ID == formObject.ID);
                residence.Name = formObject.Name;
                residence.BuildingID = formObject.BuildingID;
                context.SaveChanges();
            }
        }

        protected void Delete(int residenceID)
        {
            using (var context = this.GetApplicationContext())
            {
                var residence = context.Residences.Single(r => r.ID == residenceID);
                context.Residences.Remove(residence);
                context.SaveChanges();
            }
        }
    }
}