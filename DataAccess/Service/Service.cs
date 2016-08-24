using DataAccess.Context;

namespace DataAccess.Service
{
    public class Service
    {
        protected ApplicationContext GetApplicationContext()
        {
            return new ApplicationContext();
        }
    }
}