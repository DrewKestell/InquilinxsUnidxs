using DataAccess.Context;
using DataAccess.Model;
using System.Data.Entity.Migrations;

namespace DataAccess.Seeder
{
    public class ResidenceSeeder : ISeeder
    {
        public void Seed(ApplicationContext context)
        {
            context.Residences.AddOrUpdate(r => new { r.Name, r.BuildingID },
                new Residence
                {
                    Name = "Unit 101",
                    BuildingID = 1
                },
                new Residence
                {
                    Name = "Unit 102",
                    BuildingID = 1
                },
                new Residence
                {
                    Name = "Unit 201",
                    BuildingID = 2
                },
                new Residence
                {
                    Name = "Unit 202",
                    BuildingID = 2
                },
                new Residence
                {
                    Name = "Unit 301",
                    BuildingID = 3
                },
                new Residence
                {
                    Name = "Unit 302",
                    BuildingID = 3
                },
                new Residence
                {
                    Name = "Unit 401",
                    BuildingID = 4
                },
                new Residence
                {
                    Name = "Unit 402",
                    BuildingID = 4
                },
                new Residence
                {
                    Name = "Unit 501",
                    BuildingID = 5
                },
                new Residence
                {
                    Name = "Unit 502",
                    BuildingID = 5
                });
        }
    }
}