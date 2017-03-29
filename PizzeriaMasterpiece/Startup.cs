using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PizzeriaMasterpiece.Startup))]
namespace PizzeriaMasterpiece
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
