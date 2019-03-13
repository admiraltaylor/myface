using System;
using System.Collections.Generic;
using System.Text;
using MyFace.Domain;

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
    }
}
