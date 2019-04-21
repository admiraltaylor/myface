using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFace.Data;

namespace MyFace.Test
{
    [TestClass]
    public class RepositoryTest
    {

        UserSqliteRepository _UserSqliteRepo = new UserSqliteRepository();
        [TestMethod]
        public void GetAllUsersTest()
        {
            _UserSqliteRepo.DownloadAllUsers();
        }
    }
}
