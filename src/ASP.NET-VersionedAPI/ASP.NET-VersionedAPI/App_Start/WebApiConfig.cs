using ASP.NET_VersionedAPI.Code;
using System.Web.Http;

namespace ASP.NET_VersionedAPI
{
    public static class WebApiConfig
    {
        /// <summary>
        /// The global prefix to be used with our provider
        /// </summary>
        private const string GlobalApiPrefix = "api";

        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            // We pass an instance of the GlobalVersionedPrefixProvider with our global prefix
            // In this case the url will be <host>/api/<version>/<controller name excluding version>
            config.MapHttpAttributeRoutes(new GlobalVersionedPrefixProvider(GlobalApiPrefix));
        }
    }
}
