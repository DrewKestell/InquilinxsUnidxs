using DataAccess.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataAccess.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("name=ApplicationContext") { }

        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Landlord> Landlords { get; set; }
        public virtual DbSet<Neighborhood> Neighborhoods { get; set; }
        public virtual DbSet<Renter> Renters { get; set; }
        public virtual DbSet<Residence> Residences { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}