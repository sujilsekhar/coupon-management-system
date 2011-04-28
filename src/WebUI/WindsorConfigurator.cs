using Omu.Encrypto;
using Core.Security;
using Infra;
using WebUI.Controllers;

namespace WebUI
{
    public class WindsorConfigurator
    {
        public static void Configure()
        {
            WindsorRegistrar.Register(typeof(IFormsAuthentication), typeof(FormAuthService));
            WindsorRegistrar.Register(typeof(IHasher), typeof(Hasher));
            WindsorRegistrar.RegisterAllFromAssemblies("Data");
            WindsorRegistrar.RegisterAllFromAssemblies("Service");
            WindsorRegistrar.RegisterAllFromAssemblies("Infra");
        }
    }
}