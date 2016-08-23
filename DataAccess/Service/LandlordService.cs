using DataAccess.DTO;
using DataAccess.FormObject;
using DataAccess.Model;
using System;
using System.Linq;

namespace DataAccess.Service
{
    public class LandlordService : Service
    {
        protected PaginationDTO<Landlord> GetLandlords(int page, int pageSize)
        {
            using (var context = this.GetApplicationContext())
            {
                var model = context.Landlords
                    .OrderBy(l => l.LastName)
                    .ThenBy(l => l.FirstName)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var totalRecords = context.Landlords.Count();
                var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize); // FIXME: this feels ugly

                return new PaginationDTO<Landlord>(model, totalRecords, totalPages);
            }
        }

        protected Landlord GetLandlord(int landlordID)
        {
            using (var context = this.GetApplicationContext())
            {
                return context.Landlords
                    .Single(r => r.ID == landlordID);
            }
        }

        // TODO: share code with Update
        protected void Create(LandlordFormObject formObject)
        {
            using (var context = this.GetApplicationContext())
            {
                context.Landlords.Add(new Landlord
                {
                    FirstName = formObject.FirstName,
                    LastName = formObject.LastName
                });
                context.SaveChanges();
            }
        }

        // TODO: share code with Create
        protected void Update(LandlordFormObject formObject)
        {
            using (var context = this.GetApplicationContext())
            {
                var landlord = context.Landlords.Single(r => r.ID == formObject.ID);
                landlord.FirstName = formObject.FirstName;
                landlord.LastName = formObject.LastName;
                context.SaveChanges();
            }
        }

        protected void Delete(int landlordID)
        {
            using (var context = this.GetApplicationContext())
            {
                var landlord = context.Landlords.Single(r => r.ID == landlordID);
                context.Landlords.Remove(landlord);
                context.SaveChanges();
            }
        }
    }
}