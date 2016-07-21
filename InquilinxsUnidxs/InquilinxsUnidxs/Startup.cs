using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InquilinxsUnidxs.Startup))]
namespace InquilinxsUnidxs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
