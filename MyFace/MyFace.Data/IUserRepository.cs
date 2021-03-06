﻿using System.Collections.Generic;
using MyFace.Domain;

namespace MyFace.Data
{
    public interface IUserRepository
    {
        List<User> DownloadAllUsers();
        User DownloadSingleUser(int id);
        User SignUpNewUser(string firstName, string lastName, string email, string password);
        User LogInUser(string email, string password);
    }
}