using DataAccess.Seeder;
using System.Data.Entity;

namespace DataAccess.Context
{
    public class ApplicationContextInitializer : CreateDatabaseIfNotExists<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            // should we use reflection here to automatically grab all Seeder classes and call their Seed method?
            // if so, test speed - reflection can be slow

            // uncomment this if test data is needed

            //var fileTypeSeeder = new FileTypeSeeder();
            //fileTypeSeeder.Seed(context);

            //var landlordSeeder = new LandlordSeeder();
            //landlordSeeder.Seed(context);
            //context.SaveChanges();

            //var neighborhoodSeeder = new NeighborhoodSeeder();
            //neighborhoodSeeder.Seed(context);
            //context.SaveChanges();

            //var buildingSeeder = new BuildingSeeder();
            //buildingSeeder.Seed(context);
            //context.SaveChanges();

            //var residenceSeeder = new ResidenceSeeder();
            //residenceSeeder.Seed(context);
            //context.SaveChanges();

            //var renterSeeder = new RenterSeeder();
            //renterSeeder.Seed(context);
            //context.SaveChanges();

            //var userSeeder = new UserSeeder();
            //userSeeder.Seed(context);
            //context.SaveChanges(); 

            var stateSeeder = new StateSeeder();
            stateSeeder.Seed(context);
        }
    }
}