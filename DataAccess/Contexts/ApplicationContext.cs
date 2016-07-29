using DataAccess.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataAccess.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("name=ApplicationContext")
        {

        }

        public virtual DbSet<Renter> Renters { get; set; }
        public virtual DbSet<State> States { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}