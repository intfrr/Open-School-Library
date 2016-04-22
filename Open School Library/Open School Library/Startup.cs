using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Open_School_Library.Startup))]
namespace Open_School_Library
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
