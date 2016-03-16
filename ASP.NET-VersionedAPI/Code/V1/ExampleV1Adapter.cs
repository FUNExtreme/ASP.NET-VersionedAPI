using System.Collections.Generic;

namespace ASP.NET_VersionedAPI.Code.V1
{
    /// <summary>
    /// Example implementation of the IExampleAdapter
    /// </summary>
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
        /// Returns a single user
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve</param>
        /// <returns>The full name of the single user, or null if not found</returns>
        public string GetUser(int userId)
        {
            if (userId < 0 && userId >= _users.Count)
                return null;

            return _users[userId];
        }

        /// <summary>
        /// Returns a list of all users
        /// </summary>
        /// <returns>A list of all users</returns>
        public IEnumerable<string> GetUsers()
        {
            return _users;
        }
    }
}