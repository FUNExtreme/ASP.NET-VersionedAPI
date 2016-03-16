using ASP.NET_VersionedAPI.Code;
using ASP.NET_VersionedAPI.Code.V2._2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASP.NET_VersionedAPI.Controllers.V2._2
{
    /// <summary>
    /// Implicitly specify the route prefix of this controller within its name
    /// 
    /// The URI will be 
    /// <host>/api/v2.2/users
    /// where v'2.2' and 'users' are specified in the controller name
    /// </summary>
    public class UsersV2d2Controller : ApiController
    {
        private IExampleAdapter _adapter;

        public UsersV2d2Controller()
        {
            _adapter = new ExampleV2d2Adapter();
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
