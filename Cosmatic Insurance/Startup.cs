using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cosmatic_Insurance.Startup))]
namespace Cosmatic_Insurance
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
