using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vivlio.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using VivlioTests.Stubs;

namespace Vivlio.Tools.Tests
{
    [TestClass()]
    public class LoginValidatorTests
    {
        Vivlio.Tools.LoginValidator Validator;
        UserDALStub UserStub;
        string Username;
        string Password;

        [TestInitialize]
        public void TestInitialize()
        {
            UserStub = new UserDALStub();
            Validator = new Vivlio.Tools.LoginValidator(UserStub);
        }



        //Test ResultGet
        [TestMethod()]
        public void ResultGetNull()
        {
            Username = "jensevent";

            UserStub.TestValue = true;
            Assert.AreEqual("", Validator.Result);
        }

        [TestMethod()]
        public void ResultGetNotNull()
        {
            Username = null;

            Assert.IsNotNull(Validator.Result);
        }



        //Validate Username
        [TestMethod()]
        public void UsernameIsNull()
        {
            Username = null;

            Assert.IsFalse(Validator.ValidateUsername(Username));
        }

        [TestMethod()]
        public void UsernameIsEmpty()
        {
            Username = "";

            Assert.IsFalse(Validator.ValidateUsername(Username));
        }


        [TestMethod()]
        public void UsernameDoesntExist()
        {
            Username = "WhiteShadow";

            UserStub.TestValue = false;
            Assert.IsFalse(Validator.ValidateUsername(Username));
        }

        [TestMethod()]
        public void UsernameIsCorrect()
        {
            Username = "jensevent";

            UserStub.TestValue = true;
            Assert.IsTrue(Validator.ValidateUsername(Username));
        }



        //ValidateUsername
        [TestMethod()]
        public void PasswordIsNull()
        {
            Password = null;

            Assert.IsFalse(Validator.ValidatePassword(Password));
        }

        [TestMethod()]
        public void PasswordIsEmpty()
        {
            Password = "";

            Assert.IsFalse(Validator.ValidatePassword(Password));
        }

        [TestMethod()]
        public void PasswordIsCorrect()
        {
            Password = "Welkom12345";

            Assert.IsTrue(Validator.ValidatePassword(Password));
        }
    }
}