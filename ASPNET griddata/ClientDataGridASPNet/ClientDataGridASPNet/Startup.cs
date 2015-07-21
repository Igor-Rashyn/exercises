using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClientDataGridASPNet.Startup))]
namespace ClientDataGridASPNet
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
