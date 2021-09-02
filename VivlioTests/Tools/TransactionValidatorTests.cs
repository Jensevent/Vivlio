using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vivlio.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using VivlioTests.Stubs;

namespace Vivlio.Tools.Tests
{
    [TestClass()]
    public class TransactionValidatorTests
    {
        Tools.TransactionValidator Validator;
        BookDALStub BookStub;
        UserDALStub UserStub;

        string UserID;
        string BookID;

        // Initialize
        [TestInitialize]
        public void TestInitialize()
        {
            BookStub = new BookDALStub();
            UserStub = new UserDALStub();
            Validator = new Tools.TransactionValidator(BookStub, UserStub);
        }


        //Test ResultGet
        [TestMethod()]
        public void ResultGetNull()
        {
            UserID = "1";

            UserStub.TestValue = true;
            Assert.AreEqual("",Validator.Result);
        }

        [TestMethod()]
        public void ResultGetNotNull()
        {
            UserID = null;
            
            Assert.IsNotNull(Validator.Result);
        }




        // User ID
        [TestMethod()]
        public void UserIDIsNull()
        {
            UserID = null;

            Assert.IsFalse(Validator.ValidateUserID(UserID));
        }

        
        [TestMethod()]
        public void UserIDIsEmpty()
        {
            UserID = "";

            Assert.IsFalse(Validator.ValidateUserID(UserID));
        }
        
        
        [TestMethod()]
        public void UserIDNotNumeric()
        {
            UserID = "abcdefg";

            Assert.IsFalse(Validator.ValidateUserID(UserID));
        }


        [TestMethod()]
        public void UserIDPartialNumeric()
        {
            UserID = "abc123";

            Assert.IsFalse(Validator.ValidateUserID(UserID));
        }


        [TestMethod]
        public void UserIDDoesntExist()
        {
            UserID = "9999";

            UserStub.TestValue = false;
            Assert.IsFalse(Validator.ValidateUserID(UserID));
        }


        [TestMethod]
        public void UserIDIsCorrect()
        {
            UserID = "2";

            UserStub.TestValue = true;
            Assert.IsTrue(Validator.ValidateUserID(UserID));
        }



        //Book ID
        [TestMethod()]
        public void BookIDIsNull()
        {
            BookID = null;

            Assert.IsFalse(Validator.ValidateBookID(BookID));
        }
        

        [TestMethod()]
        public void BookIDIsEmpty()
        {
            BookID = "";

            Assert.IsFalse(Validator.ValidateBookID(BookID));
        }


        [TestMethod()]
        public void BookIDNotNumeric()
        {
            BookID = "abcdefg";

            Assert.IsFalse(Validator.ValidateBookID(BookID));
        }


        [TestMethod()]
        public void BookIDPartialNumeric()
        {
            BookID = "abc123";

            Assert.IsFalse(Validator.ValidateBookID(BookID));
        }


        [TestMethod]
        public void BookIDDoesntExist()
        {
            BookID = "9999";

            BookStub.TestValue = false;
            Assert.IsFalse(Validator.ValidateBookID(BookID));
        }


        [TestMethod]
        public void BookIDIsCorrect()
        {
            BookID = "2";

            BookStub.TestValue = true;
            Assert.IsTrue(Validator.ValidateBookID(BookID));
        }
    }
}