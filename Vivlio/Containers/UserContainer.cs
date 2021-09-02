using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Vivlio.Enum_s;
using Vivlio.Interfaces;
using Vivlio.Models;

namespace Vivlio.Containers
{
    public class UserContainer : IUserDAL
    {
        IUserDAL iUser;

        public UserContainer(IUserDAL user)
        {
            this.iUser = user;
        }

        
        public DataTable GetUsers()
        {
            return iUser.GetUsers();
        }
        public DataTable GetUserBooks(string username)
        {
            return iUser.GetUserBooks(username);
        }


        public User GetUserByUsername(string username)
        {
            return iUser.GetUserByUsername(username);
        }


        public bool CreateUser(string name, string username, DateTime birthdate, string userFunction, string email, string phonenumber, string password)
        {
            return iUser.CreateUser(name, username, birthdate, userFunction, email, phonenumber, password);
        }
        public bool Login(string username, string password)
        {
            return iUser.ValidatePassword(username,password);
        }
        

        public bool UserIDExists(int userID)
        {
            return iUser.UserIDExists(userID);
        }
        public bool UsernameExists(string username)
        {
            return iUser.UsernameExists(username);
        }
       
        
        public bool ValidatePassword(string username, string password)
        {
            return iUser.ValidatePassword(username, password);
        }

        
        public bool UpdateUser(int userID, string name, string username, string email, string phonenumber)
        {
            return iUser.UpdateUser(userID, name, username, email, phonenumber);
        }
        public bool UpdatePassword(int userID,string password)
        {
            return iUser.UpdatePassword(userID,password);
        }
        public bool UpdateUserFunction(int userID, UserFunction function)
        {
            return iUser.UpdateUserFunction(userID, function);
        }
    }
}
