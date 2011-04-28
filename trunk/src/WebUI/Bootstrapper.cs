using System.Web.Mvc;
using System.Web.Routing;
using Infra;

namespace WebUI
{
    public class Bootstrapper
    {
        public static void Bootstrap()
        {
            RouteConfigurator.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(IoC.Container));
            WindsorConfigurator.Configure();
            AwesomeConfigurator.Configure();
        }
    }
}