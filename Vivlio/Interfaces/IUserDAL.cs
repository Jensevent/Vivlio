using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Vivlio.Enum_s;
using Vivlio.Models;

namespace Vivlio.Interfaces
{
    public interface IUserDAL
    {
        bool CreateUser(string name, string username, DateTime birthdate, string email,string Userfunction, string phonenumber, string password);
        User GetUserByUsername(string Username);



        public DataTable GetUsers();
        public DataTable GetUserBooks(string username);


        bool ValidatePassword(string Username, string Password);


        public bool UserIDExists(int UserID);
        public bool UsernameExists(string Username);



        public bool UpdateUser(int userID,string name, string username, string email, string phonenumber);
        public bool UpdatePassword(int userID, string password);
        public bool UpdateUserFunction(int userID, UserFunction fuction);
    }
}
