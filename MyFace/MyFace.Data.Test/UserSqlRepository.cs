using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MyFace.Domain;

namespace MyFace.Data
{
    /// <summary>
    /// This is the repository that holds the data access methods for our Users.
    /// I don't have a repo yet so I'm just putting these dummy methods in for now.
    /// </summary>
    public class UserSqlRepository : IUserRepository
    {
        public List<User> DownloadAllUsers()
        {
            List<User> tempList = new List<User>();

            return tempList;
        }

        public User DownloadSingleUser(int id)
        {
            return new User();
        }

        public User LogInUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        public User MapReaderToUser(SqlDataReader reader)
        {
            return new User();
        }

        public User SignUpNewUser(User user, string password)
        {
            throw new NotImplementedException();
        }
    }
}
