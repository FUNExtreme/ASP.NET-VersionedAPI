using ASP.NET_VersionedAPI.Code;
using ASP.NET_VersionedAPI.Code.V1;
using System.Collections.Generic;
using System.Web.Http;

namespace ASP.NET_VersionedAPI.Controllers.V1
{
    /// <summary>
    /// Explicitly specify the route prefix of this controller
    /// </summary>
    [RoutePrefix("users")]
    public class UsersV1Controller : ApiController
    {
        private IExampleAdapter _adapter;

        public UsersV1Controller()
        {
            _adapter = new ExampleV1Adapter();
        }

        [Route()]
        public IEnumerable<string> Get()
        {
            return _adapter.GetUsers();
        }

        [Route("{userId}")]
        public string Get(int userId)
        {
            return _adapter.GetUser(userId);
        }

        [Route()]
        public void Put([FromBody]string fullName)
        {
            _adapter.AddUser(fullName);
        }
    }
}
