using DataAccess.Contexts;

namespace DataAccess.Seeders
{
    public interface ISeeder
    {
        void Seed(ApplicationContext context);
    }
}