
// Add the following usings:
using Owin;
using System.Web.Http;

namespace AgentPublishGSA
{
    public class Startup
    {
        // This method is required by Katana:
        public void Configuration(IAppBuilder app)
        {
            var webApiConfiguration = ConfigureWebApi();

            // Use the extension method provided by the WebApi.Owin library:
            app.UseWebApi(webApiConfiguration);
        }


        private HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "gsa/{controller}/{param}",
                new { param = RouteParameter.Optional });
            return config;
        }
    }
}
