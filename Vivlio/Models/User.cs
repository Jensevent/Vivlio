using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivlio.Enum_s;

namespace Vivlio.Models
{
    public class User
    {
        public int ID;
        public string Name;
        public string Username;
        public string Email;
        public string Phonenumber;
        public DateTime Birthdate;
        public UserFunction UserFunction;


        public User(int id,string name, string username, string email, string phonenumber, DateTime birthdate, UserFunction userFunction)
        {
            this.ID = id;
            this.Name = name;
            this.Username = username;
            this.Email = email;
            this.Phonenumber = phonenumber;
            this.Birthdate = birthdate;
            this.UserFunction = userFunction;
        }
    }
}
