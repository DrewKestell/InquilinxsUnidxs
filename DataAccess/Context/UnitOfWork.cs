namespace DataAccess.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationContext applicationContext;

        public UnitOfWork(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public void Save()
        {
            applicationContext.SaveChanges();
        }
    }
}