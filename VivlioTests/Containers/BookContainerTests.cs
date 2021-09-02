using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vivlio.Containers;
using System;
using System.Collections.Generic;
using System.Text;
using VivlioTests.Stubs;
using Vivlio.DAL_s;

namespace Vivlio.Containers.Tests
{
    [TestClass()]
    public class BookContainerTests
    {

        BookContainer container;
        BookDALStub BookStub;
        int bookID = 0;
        int userID = 0;

        [TestInitialize]
        public void TestInitialize()
        {
            BookStub = new BookDALStub();
            container = new BookContainer(BookStub);
        }



        [TestMethod()]
        public void LendBookTrue()
        {
            BookStub.TestValue = true;
            Assert.IsTrue(container.LendBook(userID = 1, bookID = 2));
        }

        [TestMethod()]
        public void LendBookFalse()
        {
            BookStub.TestValue = false;
            Assert.IsFalse(container.LendBook(userID = -5, bookID = -192));
        }

        [TestMethod()]
        public void ReturnBookTrue()
        {
            BookStub.TestValue = true;
            Assert.IsTrue(container.ReturnBook(userID = 1, bookID = 2));
        }

        [TestMethod()]
        public void ReturnBookFalse()
        {
            BookStub.TestValue = false;
            Assert.IsFalse(container.ReturnBook(userID = -5, bookID = -192));
        }

        [TestMethod()]
        public void GetBooksTableFilled()
        {
            BookStub.TestValue = true;
            Assert.IsNotNull(container.GetBooks());
        }

        [TestMethod()]
        public void GetBooksTableNull()
        {
            BookStub.TestValue = false;
            Assert.IsNull(container.GetBooks());
        }

        [TestMethod()]
        public void ProlongBookTrue()
        {
            BookStub.TestValue = true;
            Assert.IsTrue(container.ProlongBook(userID = 1, bookID = 2));
        }

        [TestMethod()]
        public void ProlongBookFalse()
        {
            BookStub.TestValue = false;
            Assert.IsFalse(container.ProlongBook(userID = -5, bookID = -192));
        }

        [TestMethod()]
        public void BookIDExistsTrue()
        {
            BookStub.TestValue = true;
            Assert.IsTrue(container.BookIDExists(bookID = 2));
        }

        [TestMethod()]
        public void BookIDExistsFalse()
        {
            BookStub.TestValue = false;
            Assert.IsFalse(container.BookIDExists(bookID = -192));
        }

        [TestMethod()]
        public void GetPopulairBooksTableFilled()
        {
            BookStub.TestValue = true;
            Assert.IsNotNull(container.GetPopulairBooks());
        }

        [TestMethod()]
        public void GetPopulairBooksTableNull()
        {
            BookStub.TestValue = false;
            Assert.IsNull(container.GetPopulairBooks());
        }



        [TestMethod()]
        public void UserIDBookIDExistsTrue()
        {
            BookStub.TestValue = true;
            Assert.IsTrue(container.UserIDBookIDExists(userID = 1, bookID = 1));
        }

        [TestMethod()]
        public void UserIDBookIDExistsFalse()
        {
            BookStub.TestValue = false;
            Assert.IsFalse(container.UserIDBookIDExists(userID = 1, bookID = 1));
        }
    }
}