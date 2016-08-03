using DataAccess.Seeder;
using System.Data.Entity;

namespace DataAccess.Context
{
    public class ApplicationContextInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            // should we use reflection here to automatically grab all Seeder classes and call their Seed method?
            // if so, test speed - reflection can be slow

            var stateSeeder = new StateSeeder();
            stateSeeder.Seed(context);

            var renterSeeder = new RenterSeeder();
            renterSeeder.Seed(context);

            var userSeeder = new UserSeeder();
            userSeeder.Seed(context);

            context.SaveChanges(); 
        }
    }
}