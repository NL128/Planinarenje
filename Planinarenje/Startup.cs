using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Planinarenje.Startup))]
namespace Planinarenje
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
           
        }
    }
}
