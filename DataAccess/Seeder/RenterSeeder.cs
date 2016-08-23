using DataAccess.Context;
using DataAccess.Model;
using System.Data.Entity.Migrations;

namespace DataAccess.Seeder
{
    public class RenterSeeder : ISeeder
    {
        public void Seed(ApplicationContext context)
        {
            context.Renters.AddOrUpdate(r => new { r.FirstName, r.LastName },
                new Renter
                {
                    FirstName = "Jean Luc",
                    LastName = "Picard",
                    ResidenceID = 1
                },
                new Renter
                {
                    FirstName = "William",
                    LastName = "Riker",
                    ResidenceID = 1
                },
                new Renter
                {
                    FirstName = "Mister",
                    LastName = "Data",
                    ResidenceID = 2
                },
                new Renter
                {
                    FirstName = "Geordi",
                    LastName = "La Forge",
                    ResidenceID = 2
                },
                new Renter
                {
                    FirstName = "Mister",
                    LastName = "Worf",
                    ResidenceID = 2
                },
                new Renter
                {
                    FirstName = "Wesley",
                    LastName = "Crusher",
                    ResidenceID = 3
                },
                new Renter
                {
                    FirstName = "Deanna",
                    LastName = "Troi",
                    ResidenceID = 4
                },
                new Renter
                {
                    FirstName = "Beverly",
                    LastName = "Crusher",
                    ResidenceID = 5
                },
                new Renter
                {
                    FirstName = "Tasha",
                    LastName = "Yar",
                    ResidenceID = 6
                },
                new Renter
                {
                    FirstName = "Misses",
                    LastName = "Guinan",
                    ResidenceID = 7
                },
                new Renter
                {
                    FirstName = "Lwaxana",
                    LastName = "Troi",
                    ResidenceID = 8
                },
                new Renter
                {
                    FirstName = "James",
                    LastName = "Kirk",
                    ResidenceID = 9
                },
                new Renter
                {
                    FirstName = "Mister",
                    LastName = "Spock",
                    ResidenceID = 10
                });
        }
    }
}