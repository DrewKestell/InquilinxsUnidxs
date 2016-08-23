using DataAccess.Context;
using DataAccess.Enum;
using DataAccess.Model;
using System.Data.Entity.Migrations;

namespace DataAccess.Seeder
{
    public class BuildingSeeder : ISeeder
    {
        public void Seed(ApplicationContext context)
        {
            context.Buildings.AddOrUpdate(r => new { r.Address },
                new Building
                {
                    Address = "2837 Emerson Ave",
                    City = "Minneapolis",
                    ZIP = "55408",
                    StateID = States.MN,
                    LandlordID = 1,
                    NeighborhoodID = 1
                },
                new Building
                {
                    Address = "400 Marquette Ave",
                    City = "Minneapolis",
                    ZIP = "55401",
                    StateID = States.MN,
                    LandlordID = 2,
                    NeighborhoodID = 2
                },
                new Building
                {
                    Address = "1713 Pierce St NE",
                    City = "Minneapolis",
                    ZIP = "55413",
                    StateID = States.MN,
                    LandlordID = 3,
                    NeighborhoodID = 3
                },
                new Building
                {
                    Address = "643 N 5th St",
                    City = "Minneapolis",
                    ZIP = "55401",
                    StateID = States.MN,
                    LandlordID = 4,
                    NeighborhoodID = 4
                },
                new Building
                {
                    Address = "5924 Pillysbury Ave S",
                    City = "Minneapolis",
                    ZIP = "55419",
                    StateID = States.MN,
                    LandlordID = 5,
                    NeighborhoodID = 5
                });
        }
    }
}