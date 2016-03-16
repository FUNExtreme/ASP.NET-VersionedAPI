using System;
using System.Collections.Generic;

namespace ASP.NET_VersionedAPI.Code.V1
{
    public class ExampleV1Adapter : IExampleAdapter
    {
        private List<string> _users = new List<string>
        {
            "Robin Maenhaut",
            "John Doe",
            "Jane Doe"
        };

        /// <summary>
        /// Adds a user to our list
        /// </summary>
        /// <param name="fullName">The full name of the user to add</param>
        public void AddUser(string fullName)
        {
            _users.Add(fullName);
        }

        /// <summary>
        /// Returns a list of all users
        /// </summary>
        /// <returns>A list of all users</returns>
        public List<string> GetUsers()
        {
            return _users;
        }
    }
}