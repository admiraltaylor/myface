using MyFace.Data;
using MyFace.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFace.BL
{
    public class MyFace
    {
        IUserRepository _UserRepository = new UserSqlRepository();

        // TL - 03.30.19
        // Passes a new user without Id and their password to the repository
        // The repo will store the user and their encrypted password
        // Repo will return user with Id
        // User with Id is returned
        public User SignUpNewUser(string firstName, string lastName, string email, string password)
        {
            User user = _UserRepository.SignUpNewUser(firstName, lastName, email, password);
            return user;
        }

        // TL - 03.30.19
        // Passes email and password to repo
        // Repo encrypts password and compares to stored encrypted password
        // if match, returns user data
        // else returns null
        // UI will deal with null return or take user to profile page
        public User LogInUser(string email, string password)
        {
            User user = _UserRepository.LogInUser(email, password);

            return user;
        }
    }
}
