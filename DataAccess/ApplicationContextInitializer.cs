using DataAccess.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataAccess
{
    public class ApplicationContextInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var renters = new List<Renter>
            {
                new Renter { FirstName = "William", LastName = "Riker" },
                new Renter { FirstName = "Jean Luc", LastName = "Picard" },
                new Renter { FirstName = "James", LastName = "Kirk" }
            };
            context.Renters.AddRange(renters);
            context.SaveChanges();
        }
    }
}