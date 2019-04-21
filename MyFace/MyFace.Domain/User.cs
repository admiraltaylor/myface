using System;
using System.Collections.Generic;
using System.Text;

namespace MyFace.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }

        // while I will initially put this directly into the SQLite DB, 
        // eventually this will only be stored/passed around encrypted.
        public string Password { get; set; }

        public User()
        {

        }

        public User(int id, string firstName, string lastName, string email, string status)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Status = status;
        }

        public User(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }
    }
}
