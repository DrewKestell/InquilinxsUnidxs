using DataAccess.Context;
using DataAccess.Model;
using System.Data.Entity.Migrations;

namespace DataAccess.Seeder
{
    public class LandlordSeeder : ISeeder
    {
        public void Seed(ApplicationContext context)
        {
            context.Landlords.AddOrUpdate(r => new { r.FirstName, r.LastName },
                new Landlord
                {
                    FirstName = "Samael",
                    LastName = "Aramazd"
                },
                new Landlord
                {
                    FirstName = "Geirr",
                    LastName = "Laban"
                },
                new Landlord
                {
                    FirstName = "Varnava",
                    LastName = "Lael"
                },
                new Landlord
                {
                    FirstName = "Abimelech",
                    LastName = "Ourbanos"
                },
                new Landlord
                {
                    FirstName = "Pinchas",
                    LastName = "Ezekias"
                });
        }
    }
}