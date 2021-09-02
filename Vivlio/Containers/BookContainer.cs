using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Vivlio.Interfaces;

namespace Vivlio.Containers
{
    public class BookContainer : IBookDAL
    {
        IBookDAL iBook;

        public BookContainer(IBookDAL book)
        {
            this.iBook = book;
        }


        public bool LendBook(int userID, int bookID)
        {
            return iBook.LendBook(userID, bookID);
        }
        public bool ReturnBook(int userID, int bookID)
        {
            return iBook.ReturnBook(userID, bookID);
        }
        public bool ProlongBook(int userID, int bookID)
        {
            return iBook.ProlongBook(userID, bookID);
        }


        public DataTable GetBooks()
        {
            return iBook.GetBooks();
        }
        public DataTable GetPopulairBooks()
        {
            return iBook.GetPopulairBooks();
        }


        public bool BookIDExists(int bookID)
        {
            return iBook.BookIDExists(bookID);
        }
        public bool UserIDBookIDExists(int userID, int bookID)
        {
            return iBook.UserIDBookIDExists(userID, bookID);
        }
    }   
}
