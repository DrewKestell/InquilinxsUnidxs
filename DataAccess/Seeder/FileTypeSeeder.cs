using DataAccess.Context;
using DataAccess.Enum;
using DataAccess.Model;
using System.Data.Entity.Migrations;

namespace DataAccess.Seeder
{
    public class FileTypeSeeder : ISeeder
    {
        public void Seed(ApplicationContext context)
        {
            foreach (FileTypes type in System.Enum.GetValues(typeof(FileTypes)))
            {
                context.FileTypes.AddOrUpdate(t => t.ID,
                    new FileType
                    {
                        ID = type,
                        Name = type.ToString()
                    });
                context.SaveChanges();
            }
        }
    }
}