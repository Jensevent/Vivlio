using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Vivlio.Enum_s;
using Vivlio.Interfaces;
using Vivlio.Models;

namespace VivlioTests.Stubs
{
    class UserDALStub : IUserDAL
    {
        public bool? TestValue = null;



        public bool CreateUser(string name, string username, DateTime birthdate, string email, string Userfunction, string phonenumber, string password)
        {
            if (TestValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field TestValue");
            }

            return TestValue.Value;
        }

        public DataTable GetUserBooks(string username)
        {
            if (TestValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field TestValue");
            }

            DataTable table = null;
            if (TestValue.Value)
            {
                table = new DataTable();
                table.Columns.Add("ID", typeof(int));
            }
            return table;
        }

        public User GetUserByUsername(string Username)
        {
            if (TestValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field TestValue");
            }

            User user = null;
            if (TestValue.Value)
            {
                user = new User(1,"Jens", "Jensevent", "jens@gmail.com", "06-12345678", DateTime.Now, UserFunction.Employee);
            }
            return user;
        }

        public DataTable GetUsers()
        {
            if (TestValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field TestValue");
            }

            DataTable table = null;
            if (TestValue.Value)
            {
                table = new DataTable();
                table.Columns.Add("ID", typeof(int));
            }

            return table;
        }

        public bool UpdatePassword(int userID, string password)
        {
            if (TestValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field TestValue");
            }

            return TestValue.Value;
        }

        public bool UpdateUser(int userID, string name, string username, string email, string phonenumber)
        {
            if (TestValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field TestValue");
            }

            return TestValue.Value;
        }

        public bool UpdateUserFunction(int userID, UserFunction fuction)
        {
            if (TestValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field TestValue");
            }

            return TestValue.Value;
        }

        public bool UserIDExists(int UserID)
        {
            if (TestValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field TestValue");
            }

            return TestValue.Value;
        }

        public bool UsernameExists(string Username)
        {
            if (TestValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field TestValue");
            }

            return TestValue.Value;
        }

        public bool ValidatePassword(string Username, string Password)
        {
            if (TestValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field TestValue");
            }

            return TestValue.Value;
        }
    }
}
