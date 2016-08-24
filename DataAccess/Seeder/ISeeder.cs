using DataAccess.Context;

namespace DataAccess.Seeder
{
    public interface ISeeder
    {
        void Seed(ApplicationContext context);
    }
}