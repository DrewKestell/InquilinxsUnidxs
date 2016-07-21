using DataAccess.FormObjects;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Services
{
    public class RenterService : Service
    {
        protected List<Renter> GetRenters()
        {
            using (var context = this.GetApplicationContext())
            {
                return context.Renters.ToList();
            }
        }

        protected Renter GetRenter(int renterID)
        {
            using (var context = this.GetApplicationContext())
            {
                return context.Renters.Single(r => r.ID == renterID);
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
                    LastName = formObject.LastName
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