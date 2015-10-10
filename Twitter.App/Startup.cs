using Microsoft.Owin;

using Twitter.App;

[assembly: OwinStartup(typeof(Startup))]

namespace Twitter.App
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}