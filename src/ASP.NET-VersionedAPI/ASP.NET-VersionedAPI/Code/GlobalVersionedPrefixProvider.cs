using System.Web.Http.Controllers;
using System.Web.Http.Routing;

namespace ASP.NET_VersionedAPI.Code
{
    /// <summary>
    /// Allows for easy versioning of an API by extracting the version number from the controller name and using it in the url
    /// 
    /// Versioning syntax: a controller for version 1.2.4 becomes <name>V1d2d4Controller
    /// </summary>
    public class GlobalVersionedPrefixProvider : DefaultDirectRouteProvider
    {
        /// <summary>
        /// Global prefix, usually "api" to be prepended to the full versioned prefix
        /// </summary>
        private readonly string _prefix;

        public GlobalVersionedPrefixProvider(string prefix)
        {
            _prefix = prefix;
        }

        protected override string GetRoutePrefix(HttpControllerDescriptor controllerDescriptor)
        {
            // This will store the version of the controller, if the name contains one
            string version = null;

            // Get route prefix defined in the controller
            var existingPrefix = base.GetRoutePrefix(controllerDescriptor);

            // Extract the version number from our controller name
            int versionLocation = controllerDescriptor.ControllerName.LastIndexOf("V");
            if (versionLocation != -1)
            {
                versionLocation += "V".Length;
                version = controllerDescriptor.ControllerName.Substring(versionLocation);

                // Check if it's a valid version number
                foreach (char c in version)
                {
                    if (!char.IsDigit(c) && c != 'd') // We allow 'd' as a replacement for . (dot)
                        return CreateRoutePrefix(_prefix, null, existingPrefix);
                }

                // We want the version number seperated by dots
                version = version.Replace('d', '.');
            }

            // Return the global route prefix
            return CreateRoutePrefix(_prefix, version, existingPrefix);
        }

        /// <summary>
        /// Creates a route prefix based on the given parameters
        /// </summary>
        /// <param name="prefix">The global prefix for the api, usually "api"</param>
        /// <param name="version">The version number of the controller, will be prefixed with a "v". If empty it is ignored and excluded from the url</param>
        /// <param name="existingPrefix">Prefix defined by the controller</param>
        /// <returns></returns>
        private string CreateRoutePrefix(string prefix, string version, string existingPrefix)
        {
            if (version != null)
                return string.Format("{0}/v{1}/{2}", _prefix, version, (existingPrefix ?? ""));
            else
                return string.Format("{0}/{1}", _prefix, (existingPrefix ?? ""));
        }
    }
}