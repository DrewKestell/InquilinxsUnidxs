using DataAccess.Context;
using DataAccess.Enum;
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
                    Address = new Address
                    {
                        Address1 = "918 N 3rd St",
                        Address2 = "Unit 210",
                        City = "Minneapolis",
                        ZIP = "55401",
                        StateID = States.MN
                    }
                },
                new Renter
                {
                    FirstName = "William",
                    LastName = "Riker",
                    Address = new Address
                    {
                        Address1 = "919 W 36th St",
                        City = "Minneapolis",
                        ZIP = "55408",
                        StateID = States.MN
                    }
                },
                new Renter
                {
                    FirstName = "Mister",
                    LastName = "Data",
                    Address = new Address
                    {
                        Address1 = "5216 Minnehaha Ave",
                        City = "Minneapolis",
                        ZIP = "55417",
                        StateID = States.MN
                    }
                },
                new Renter
                {
                    FirstName = "Geordi",
                    LastName = "La Forge",
                    Address = new Address
                    {
                        Address1 = "12450 Flanders Ct NE",
                        Address2 = "Unit F",
                        City = "Blaine",
                        ZIP = "55449",
                        StateID = States.MN
                    }
                },
                new Renter
                {
                    FirstName = "Mister",
                    LastName = "Worf",
                    Address = new Address
                    {
                        Address1 = "3236 129th Ln NW",
                        City = "Coon Rapids",
                        ZIP = "55448",
                        StateID = States.MN
                    }
                },
                new Renter
                {
                    FirstName = "Wesley",
                    LastName = "Crusher",
                    Address = new Address
                    {
                        Address1 = "1600 41st Ave N,",
                        City = "Minneapolis",
                        ZIP = "55412",
                        StateID = States.MN
                    }
                },
                new Renter
                {
                    FirstName = "Deanna",
                    LastName = "Troi",
                    Address = new Address
                    {
                        Address1 = "4109 Beard Ave N",
                        City = "Robbinsdale",
                        ZIP = "55422",
                        StateID = States.MN
                    }
                },
                new Renter
                {
                    FirstName = "Beverly",
                    LastName = "Crusher",
                    Address = new Address
                    {
                        Address1 = "2800 Hillsboro Ave N",
                        Address2 = "Apt 305",
                        City = "New Hope",
                        ZIP = "55427",
                        StateID = States.MN
                    }
                },
                new Renter
                {
                    FirstName = "Tasha",
                    LastName = "Yar",
                    Address = new Address
                    {
                        Address1 = "3028 Buchanan St NE",
                        City = "Minneapolis",
                        ZIP = "55418",
                        StateID = States.MN
                    }
                },
                new Renter
                {
                    FirstName = "Misses",
                    LastName = "Guinan",
                    Address = new Address
                    {
                        Address1 = "6336 Josephine Ave",
                        City = "Edina",
                        ZIP = "55439",
                        StateID = States.MN
                    }
                },
                new Renter
                {
                    FirstName = "Lwaxana",
                    LastName = "Troi",
                    Address = new Address
                    {
                        Address1 = "3709 20th Ave S",
                        City = "Minneapolis",
                        ZIP = "55407",
                        StateID = States.MN
                    }
                },
                new Renter
                {
                    FirstName = "James",
                    LastName = "Kirk",
                    Address = new Address
                    {
                        Address1 = "5616 Winnetka Ave N",
                        City = "New Hope",
                        ZIP = "55428",
                        StateID = States.MN
                    }
                },
                new Renter
                {
                    FirstName = "Mister",
                    LastName = "Spock",
                    Address = new Address
                    {
                        Address1 = "5134 N Sheridan Ave",
                        Address2 = "Unit 210",
                        City = "Minneapolis",
                        ZIP = "55430",
                        StateID = States.MN
                    }
                });
        }
    }
}