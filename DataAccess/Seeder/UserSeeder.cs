using DataAccess.Context;
using DataAccess.Model;
using System.Data.Entity.Migrations;

namespace DataAccess.Seeder
{
    public class UserSeeder : ISeeder
    {
        public void Seed(ApplicationContext context)
        {
            //context.Users.AddOrUpdate(u => u.Username,
            //    new User
            //    {
            //        Username = "admin",
            //        Password = "password".GetHashCode(),
            //        Email = "drew.kestell@gmail.com"
            //    });
        }
    }
}
