using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieReview_Website_Adv_DotNet.Startup))]
namespace MovieReview_Website_Adv_DotNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
