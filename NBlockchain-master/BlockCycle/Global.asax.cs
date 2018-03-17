using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BlockCycle.UI.DAL;
using BlockCycle.UI.Services;
using Unity;
using Unity.Lifetime;

namespace BlockCycle.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            InitIoc();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void InitIoc()
        {
            BlockChainEntities blockChainEntities = new BlockChainEntities();
            BlockCycleContainer.Container.RegisterType<BlockChainEntities>(new PerResolveLifetimeManager());

            BlockCycleContainer.Container.RegisterType<OpenData>(new SingletonLifetimeManager());
            BlockCycleContainer.Container.RegisterType<BlockService>(new SingletonLifetimeManager());
        }
    }
}
