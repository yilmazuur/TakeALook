using System.Collections.Generic;
using System.Web;
using System.Web.Caching;
namespace TakeALook.API
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //control dllindeki virtual pathleri anlamlandırmak için
            System.Web.Hosting.HostingEnvironment.RegisterVirtualPathProvider(new AssemblyResourceProvider());
            LoadStatsCache();
        }

        static private void LoadStatsCache()
        {
            //REMOVED BEACUSE OF SECURITY
        }
    }
}
