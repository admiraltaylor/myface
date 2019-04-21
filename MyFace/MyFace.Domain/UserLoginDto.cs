using System;
using System.Collections.Generic;
using System.Text;

namespace MyFace.Domain
{
    public class UserLoginDto
    {
        int Id { get; set; }
        string Email { get; set; }
        string Password { get; set; }

        public UserLoginDto()
        {

        }

        public UserLoginDto(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
    
}
