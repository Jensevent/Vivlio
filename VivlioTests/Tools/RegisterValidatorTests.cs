using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vivlio.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using VivlioTests.Stubs;

namespace Vivlio.Tools.Tests
{
    [TestClass()]
    public class RegisterValidatorTests
    {

        string Name;
        string Username;
        DateTime? Birthdate;
        string Email;
        string Phonenumber;
        string Password;
        string RepeatPassword;
        string UserFunction;

        UserDALStub UserStub;
        Vivlio.Tools.RegisterValidator Validator;




        [TestInitialize]
        public void TestInitialize()
        {
            UserStub = new UserDALStub();
            Validator = new Vivlio.Tools.RegisterValidator(UserStub);
        }


        //Test ResultGet
        [TestMethod()]
        public void ResultGetNull()
        {
            Name = "1";

            UserStub.TestValue = true;
            Assert.AreEqual("", Validator.Result);
        }

        [TestMethod()]
        public void ResultGetNotNull()
        {
            Name = null;

            Assert.IsNotNull(Validator.Result);
        }





        // Validate name
        [TestMethod()]
        public void NameIsNull()
        {
            Name = null;

            Assert.IsFalse(Validator.ValidateName(Name));
        }


        [TestMethod()]
        public void NameIsEmpty()
        {
            Name = "";

            Assert.IsFalse(Validator.ValidateName(Name));
        }


        [TestMethod()]
        public void NameNotAlphabetic()
        {
            Name = "12345678";

            Assert.IsFalse(Validator.ValidateName(Name));
        }


        [TestMethod()]
        public void NamePartialAlphabetic()
        {
            Name = "abcde12345";

            Assert.IsFalse(Validator.ValidateName(Name));
        }


        [TestMethod()]
        public void NameIsCorrect()
        {
            Name = "Bart";

            Assert.IsTrue(Validator.ValidateName(Name));
        }



        // Valdiate Username 
        [TestMethod()]
        public void UsernameIsNull()
        {
            Username = null;

            Assert.IsFalse(Validator.ValidateUsername(Username,true));
        }


        [TestMethod()]
        public void UsernameIsEmpty()
        {
            Username = "";

            Assert.IsFalse(Validator.ValidateUsername(Username,true));
        }


        [TestMethod()]
        public void UsernameTooShort()
        {
            Username = "Bart";

            Assert.IsFalse(Validator.ValidateUsername(Username,true));
        }

        [TestMethod]
        public void UsernameNotAlphabetic()
        {
            Username = "123456";

            Assert.IsFalse(Validator.ValidateUsername(Username, true));
        }

        [TestMethod()]
        public void UsernameAlreadyExists()
        {
            Username = "Jensevent";

            UserStub.TestValue = true;
            Assert.IsFalse(Validator.ValidateUsername(Username,true));
        }


        [TestMethod()]
        public void UsernameIsCorrect()
        {
            Username = "Lodewijk12";

            UserStub.TestValue = false;
            Assert.IsTrue(Validator.ValidateUsername(Username,true));
        }




        // Validate Birthdate
        [TestMethod()]
        public void BirthdateIsNull()
        {
            Birthdate = null;

            Assert.IsFalse(Validator.ValidateBirthdate(Birthdate));
        }

        [TestMethod()]
        public void BirthdateNoDate()
        {
            Birthdate = DateTime.MinValue;

            Assert.IsFalse(Validator.ValidateBirthdate(Birthdate));
        }


        [TestMethod()]
        public void BirthdateIsTooYoung()
        {
            Birthdate = new DateTime(2016, 2, 2);

            Assert.IsFalse(Validator.ValidateBirthdate(Birthdate));
        }


        [TestMethod()]
        public void BirthdateOutOfRange()
        {
            Birthdate = DateTime.Now.AddYears(201);
            Assert.IsFalse(Validator.ValidateBirthdate(Birthdate));

            Birthdate = DateTime.Now.AddYears(-201);
            Assert.IsFalse(Validator.ValidateBirthdate(Birthdate));
        }

        

        [TestMethod()]
        public void BirthdateIsCorrect()
        {
            Birthdate = new DateTime(2014, 3, 6);

            Assert.IsTrue(Validator.ValidateBirthdate(Birthdate));
        }


        


        // Validate UserFunction
        [TestMethod()]
        public void UserFunctionIsNull()
        {
            UserFunction = null;

            Assert.IsFalse(Validator.ValidateUserFunction(UserFunction));
        }


        [TestMethod()]
        public void UserFunctionIsEmpty()
        {
            UserFunction = "";

            Assert.IsFalse(Validator.ValidateUserFunction(UserFunction));
        }

        [TestMethod()]
        public void UserFunctionCorrect()
        {
            UserFunction = "Member";

            Assert.IsTrue(Validator.ValidateUserFunction(UserFunction));
        }




        // Validate Email
        [TestMethod()]
        public void EmailIsNull()
        {
            Email = null;

            Assert.IsFalse(Validator.ValidateEmail(Email));
        }


        [TestMethod()]
        public void EmailIsEmpty()
        {
            Email = "";

            Assert.IsFalse(Validator.ValidateEmail(Email));
        }


        [TestMethod()]
        public void EmailIsWrongFormat()
        {
            // No @ or TLD (.com /.nl / .be etc.) or 
            Email = "dora"; 

            Assert.IsFalse(Validator.ValidateEmail(Email));

            // No TLD
            Email = "dora@gmail";

            Assert.IsFalse(Validator.ValidateEmail(Email));

            // TLD is too long (min 2 char, max 3)
            Email = "dora@gmail.fiets";

            Assert.IsFalse(Validator.ValidateEmail(Email));
        }


        [TestMethod()]
        public void EmailCorrect()
        {
            Email = "jheesbeen@gmail.com";

            Assert.IsTrue(Validator.ValidateEmail(Email));
        }




        //Validate Phonenumber
        [TestMethod()]
        public void PhonenumberIsNull()
        {
            // Phonenumber is optional, so its allowed to be null
            Phonenumber = null;

            Assert.IsTrue(Validator.ValidatePhoneNumber(Phonenumber));
        }


        [TestMethod()]
        public void PhonenumberIsEmpty()
        {
            // Same goes for if its empty
            Phonenumber = "";

            Assert.IsTrue(Validator.ValidatePhoneNumber(Phonenumber));
        }

        [TestMethod()]
        public void PhonenumberAlphabetic()
        {
            Phonenumber = "abcdefgh";

            Assert.IsFalse(Validator.ValidatePhoneNumber(Phonenumber));
        }

        [TestMethod()]
        public void PhonenumberIsPartialAlphabetic()
        {
            Phonenumber = "abcde12345";

            Assert.IsFalse(Validator.ValidatePhoneNumber(Phonenumber));
        }


        [TestMethod()]
        public void PhonenumberIsTooLong()
        {
            Phonenumber = "12345678901";

            Assert.IsFalse(Validator.ValidatePhoneNumber(Phonenumber));
        }


        [TestMethod()]
        public void PhonenumberIsCorrect()
        {
            // If something is entered then it has to be in numbers
            Phonenumber = "0612345678";

            Assert.IsTrue(Validator.ValidatePhoneNumber(Phonenumber));
        }




        // Validate Password
        [TestMethod()]
        public void PasswordIsNull()
        {
            Password = null;
            RepeatPassword = "Dwarf12345";

            Assert.IsFalse(Validator.ValidatePassword(Password,RepeatPassword));

            Password = "Dwarf12345";
            RepeatPassword = null ;

            Assert.IsFalse(Validator.ValidatePassword(Password, RepeatPassword));

            Password = null;
            RepeatPassword = null;

            Assert.IsFalse(Validator.ValidatePassword(Password, RepeatPassword));
        }


        [TestMethod()]
        public void PasswordIsEmpty()
        {
            Password = "";
            RepeatPassword = "Dwarf12345";

            Assert.IsFalse(Validator.ValidatePassword(Password, RepeatPassword));

            Password = "Dwarf12345";
            RepeatPassword = "";

            Assert.IsFalse(Validator.ValidatePassword(Password, RepeatPassword));

            Password = "";
            RepeatPassword = "";

            Assert.IsFalse(Validator.ValidatePassword(Password, RepeatPassword));
        }


        [TestMethod()]
        public void PasswordsDontMatch()
        {
            Password = "Orc123456";
            RepeatPassword = "Dwarf12345";

            Assert.IsFalse(Validator.ValidatePassword(Password, RepeatPassword));
        }


        [TestMethod()]
        public void PasswordIsWrongFormat()
        {
            // Too short (min 8 char)
            Password = "Orc1234";
            RepeatPassword = "Orc1234";

            Assert.IsFalse(Validator.ValidatePassword(Password, RepeatPassword));

            //No caps
            Password = "dwarf12345";
            RepeatPassword = "dwarf12345";

            Assert.IsFalse(Validator.ValidatePassword(Password, RepeatPassword));

            // no lowercase letters
            Password = "DWARF12345";
            RepeatPassword = "DWARF12345";

            Assert.IsFalse(Validator.ValidatePassword(Password, RepeatPassword));
        }


        [TestMethod()]
        public void PasswordIsCorrect()
        {
            // Too short (min 8 char)
            Password = "Dwarf12345";
            RepeatPassword = "Dwarf12345";    

            Assert.IsTrue(Validator.ValidatePassword(Password, RepeatPassword));
        }
    }
}