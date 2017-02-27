using Autofac;
using Autofac.Integration.Mvc;
using System.Data.Entity.Migrations;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace InquilinxsUnidxs
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DependencyResolver.SetResolver(new AutofacDependencyResolver(BuildContainer()));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var configuration = new DataAccess.Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }

        static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            var thisAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyModules(thisAssembly);
            return builder.Build();
        }
    }
}