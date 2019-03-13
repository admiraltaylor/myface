using System.Collections.Generic;
using MyFace.Domain;

namespace MyFace.Data
{
    public interface IUserRepository
    {
        List<User> DownloadAllUsers();
        User DownloadSingleUser(int id);
    }
}