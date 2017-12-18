using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecipeManagmentSystem.Startup))]
namespace RecipeManagmentSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
