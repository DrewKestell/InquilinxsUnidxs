using DataAccess.Context;
using DataAccess.Model;
using System.Data.Entity.Migrations;

namespace DataAccess.Seeder
{
    public class NeighborhoodSeeder : ISeeder
    {
        public void Seed(ApplicationContext context)
        {
            context.Neighborhoods.AddOrUpdate(r => new { r.Name },
                new Neighborhood
                {
                    Name = "Uptown"
                },
                new Neighborhood
                {
                    Name = "Downtown"
                },
                new Neighborhood
                {
                    Name = "Northeast"
                },
                new Neighborhood
                {
                    Name = "North Loop"
                },
                new Neighborhood
                {
                    Name = "Tangletown"
                });
        }
    }
}