using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vivlio.Containers;
using System;
using System.Collections.Generic;
using System.Text;
using VivlioTests.Stubs;

namespace Vivlio.Containers.Tests
{
    [TestClass()]
    public class UserContainerTests
    {
        UserContainer container;
        UserDALStub UserStub;

        [TestInitialize]
        public void TestInitialize()
        {
            UserStub = new UserDALStub();
            container = new UserContainer(UserStub);
        }

        [TestMethod()]
        public void LoginTrue()
        {
            UserStub.TestValue = true;
            Assert.IsTrue( container.Login("username", "password"));
        }

        [TestMethod()]
        public void LoginFalse()
        {
            UserStub.TestValue = false;
            Assert.IsFalse(container.Login("username", "password"));
        }

        [TestMethod()]
        public void GetUsersTableFilled()
        {
            UserStub.TestValue = true;
            Assert.IsNotNull(container.GetUsers());
        }

        [TestMethod()]
        public void GetUsersTableNull()
        {
            UserStub.TestValue = false;
            Assert.IsNull(container.GetUsers());
        }


        [TestMethod()]
        public void GetUserByUsernameUserFilled()
        {
            UserStub.TestValue = true;

            Assert.IsNotNull(container.GetUserByUsername("username"));

        }

        [TestMethod()]
        public void GetUserByUsernameUserNull()
        {
            UserStub.TestValue = false;

            Assert.IsNull(container.GetUserByUsername("username"));

        }

        [TestMethod()]
        public void CreateUserTrue()
        {
            UserStub.TestValue = true;
            Assert.IsTrue(container.CreateUser("name", "username", DateTime.Now, "userfunction", "email", "phonenumber", "password"));
        }

        [TestMethod()]
        public void CreateUserFalse()
        {
            UserStub.TestValue = false;
            Assert.IsFalse(container.CreateUser("name", "username", DateTime.Now, "userfunction", "email", "phonenumber", "password"));
        }



        [TestMethod()]
        public void GetUserBooksTableFilled()
        {
            UserStub.TestValue = true;
            Assert.IsNotNull(container.GetUserBooks("username"));
        }

        [TestMethod()]
        public void GetUserBooksTableNull()
        {
            UserStub.TestValue = false;
            Assert.IsNull(container.GetUserBooks("username"));
        }


        [TestMethod()]
        public void UserIDExistsTrue()
        {
            UserStub.TestValue = true;
            Assert.IsTrue(container.UserIDExists(1));
        }

        [TestMethod()]
        public void UserIDExistsFalse()
        {
            UserStub.TestValue = false;
            Assert.IsFalse(container.UserIDExists(-1));
        }

        [TestMethod()]
        public void ValidatePasswordTrue()
        {
            UserStub.TestValue = true;
            Assert.IsTrue(container.ValidatePassword("username", "password"));
        }

        [TestMethod()]
        public void ValidatePasswordFalse()
        {
            UserStub.TestValue = false;
            Assert.IsFalse(container.ValidatePassword("username", "password"));
        }

        [TestMethod()]
        public void UsernameExistsTrue()
        {
            UserStub.TestValue = true;
            Assert.IsTrue(container.UsernameExists("username"));
        }

        [TestMethod()]
        public void UsernameExistsFalse()
        {
            UserStub.TestValue = false;
            Assert.IsFalse(container.UsernameExists("username"));
        }


        [TestMethod()]
        public void UpdateUserTrue()
        {
            UserStub.TestValue = true;
            Assert.IsTrue(container.UpdateUser(1,"name","username","email","1234567"));
        }

        [TestMethod()]
        public void UpdateUserFalse()
        {
            UserStub.TestValue = false;
            Assert.IsFalse(container.UpdateUser(1, "name", "username", "email", "1234567"));
        }


        [TestMethod()]
        public void UpdatePasswordTrue()
        {
            UserStub.TestValue = true;
            Assert.IsTrue(container.UpdatePassword(1,"password"));
        }

        [TestMethod()]
        public void UpdatePasswordFalse()
        {
            UserStub.TestValue = false;
            Assert.IsFalse(container.UpdatePassword(1, "password"));
        }


        [TestMethod()]
        public void UpdateUserFunctionTrue()
        {
            UserStub.TestValue = true;
            Assert.IsTrue(container.UpdateUserFunction(1, Enum_s.UserFunction.Employee));
        }

        [TestMethod()]
        public void UpdateUserFunctionFalse()
        {
            UserStub.TestValue = false;
            Assert.IsFalse(container.UpdateUserFunction(1, Enum_s.UserFunction.Employee));
        }
    }
}