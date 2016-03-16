using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_VersionedAPI.Code
{
    /// <summary>
    /// Interface that all versions of the API should conform with, the implementation however is version dependent
    /// </summary>
    public interface IExampleAdapter
    {
        // Users
        IEnumerable<string> GetUsers();
        string GetUser(int userId);

        void AddUser(string fullName);
    }
}