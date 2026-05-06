using GerenciamentoProdutos.Web.App_Start;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace GerenciamentoProdutos.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {

        private static readonly ILog _log = LogManager.GetLogger(typeof(MvcApplication));

        protected void Application_Start()
        {

            AutofacConfig.RegisterComponents();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            _log.Info("Aplicação iniciada");

        }
    }
}
