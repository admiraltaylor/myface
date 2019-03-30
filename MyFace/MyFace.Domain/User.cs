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

        public User()
        {

        }

        public User(int id, string firstName, string lastName, string email, string status, string message)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Status = status;
            this.Message = message;
        }

        public User(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }
    }
}
