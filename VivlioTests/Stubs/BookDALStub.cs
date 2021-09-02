using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Vivlio.Interfaces;

namespace VivlioTests.Stubs
{
    class BookDALStub : IBookDAL
    {
        public bool? TestValue = null;


        public bool BookExists(int BookID)
        {
            if (TestValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field TestValue");
            }

            return TestValue.Value;
        }


        public DataTable GetBooks()
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


        public bool LendBook(int UserID, int BookID)
        {
            if (TestValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field TestValue");
            }

            return TestValue.Value;
        }


        public bool ReturnBook(int UserID, int BookID)
        {
            if (TestValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field TestValue");
            }

            return TestValue.Value;
        }


        public bool ProlongBook(int userID, int bookID)
        {
            if (TestValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field TestValue");
            }

            return TestValue.Value;
        }

        public bool BookIDExists(int BookID)
        {
            if (TestValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field TestValue");
            }

            return TestValue.Value;
        }

        public DataTable GetPopulairBooks()
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

        public bool UserIDBookIDExists(int userID, int bookID)
        {
            if (TestValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field TestValue");
            }

            return TestValue.Value;
        }
    }
}
