using System;
using System.Collections.Generic;
using System.Text;
using MyFace.Domain;
using System.Configuration.ConfigurationManager;

namespace MyFace.Data
{

    /// <summary>
    /// A Sqlite Repository for the MyFace Application
    /// </summary>
    public class UserSqliteRepository : IUserRepository
    {
        public List<User> DownloadAllUsers()
        {
            throw new NotImplementedException();
        }

        public User DownloadSingleUser(int id)
        {
            throw new NotImplementedException();
        }

        public User LogInUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        public User SignUpNewUser(User user, string password)
        {
            throw new NotImplementedException();
        }

        private static string SqliteConnString(string Id = "SqlLiteDefault")
        {
            return System.Configuration
        }
    }
}
