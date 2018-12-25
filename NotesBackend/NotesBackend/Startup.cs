using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(NotesBackend.Startup))]

namespace NotesBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}