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
        protected List<State> GetStates()
        {
            using (var context = this.GetApplicationContext())
            {
                return context.States
                    .ToList();
            }
        }

        protected PaginationDTO<Renter> GetRenters(int page, int pageSize)
        {
            using (var context = this.GetApplicationContext())
            {
                var model = context.Renters
                    .Include("Address.State")
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
                    .Include("Address.State")
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
                    Address = new Address
                    {
                        Address1 = formObject.Address1,
                        Address2 = formObject.Address2,
                        City = formObject.City,
                        StateID = formObject.StateID,
                        ZIP = formObject.ZIP
                    }
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
                renter.Address.Address1 = formObject.Address1;
                renter.Address.Address2 = formObject.Address2;
                renter.Address.City = formObject.City;
                renter.Address.StateID = formObject.StateID;
                renter.Address.ZIP = formObject.ZIP;
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