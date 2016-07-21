namespace DataAccess.Services
{
    public class Service
    {
        protected ApplicationContext GetApplicationContext()
        {
            return new ApplicationContext();
        }
    }
}
