using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Vivlio.Interfaces
{
    public interface IBookDAL
    {
        public bool LendBook(int UserID, int BookID);
        public bool ReturnBook(int UserID, int BookID);
        public bool ProlongBook(int userID, int bookID);


        public DataTable GetPopulairBooks();
        public DataTable GetBooks();
        

        public bool BookIDExists(int BookID);
        public bool UserIDBookIDExists(int userID, int bookID);
    }
}
