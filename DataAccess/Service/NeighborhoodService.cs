using DataAccess.DTO;
using DataAccess.FormObject;
using DataAccess.Model;
using System;
using System.Linq;

namespace DataAccess.Service
{
    public class NeighborhoodService : Service
    {
        protected PaginationDTO<Neighborhood> GetNeighborhoods(int page, int pageSize)
        {
            using (var context = this.GetApplicationContext())
            {
                var model = context.Neighborhoods
                    .OrderBy(n => n.Name)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var totalRecords = context.Neighborhoods.Count();
                var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize); // FIXME: this feels ugly

                return new PaginationDTO<Neighborhood>(model, totalRecords, totalPages);
            }
        }

        protected Neighborhood GetNeighborhood(int neighborhoodID)
        {
            using (var context = this.GetApplicationContext())
            {
                return context.Neighborhoods
                    .Single(r => r.ID == neighborhoodID);
            }
        }

        // TODO: share code with Update
        protected void Create(NeighborhoodFormObject formObject)
        {
            using (var context = this.GetApplicationContext())
            {
                context.Neighborhoods.Add(new Neighborhood
                {
                    Name = formObject.Name
                });
                context.SaveChanges();
            }
        }

        // TODO: share code with Create
        protected void Update(NeighborhoodFormObject formObject)
        {
            using (var context = this.GetApplicationContext())
            {
                var neighborhood = context.Neighborhoods.Single(n => n.ID == formObject.ID);
                neighborhood.Name = formObject.Name;
                context.SaveChanges();
            }
        }

        protected void Delete(int neighborhoodID)
        {
            using (var context = this.GetApplicationContext())
            {
                var neighborhood = context.Neighborhoods.Single(r => r.ID == neighborhoodID);
                context.Neighborhoods.Remove(neighborhood);
                context.SaveChanges();
            }
        }
    }
}