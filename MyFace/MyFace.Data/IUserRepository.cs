using System.Collections.Generic;
using MyFace.Domain;

namespace MyFace.Data
{
    public interface IUserRepository
    {
        List<User> DownloadAllUsers();
        User DownloadSingleUser(int id);
        User SignUpNewUser(User user, string password);
        User LogInUser(string email, string password);
    }
}