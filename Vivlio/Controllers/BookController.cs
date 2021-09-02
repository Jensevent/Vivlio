using Microsoft.AspNetCore.Mvc;
using System;
using Vivlio.Containers;
using Vivlio.DAL_s;
using Vivlio.Interfaces;
using Vivlio.Tools;


namespace Vivlio.Controllers
{
    public class BookController : Controller
    {
        BookContainer bookShelf;
        TransactionValidator TransactionVal;

        public BookController()
        {
            IBookDAL iBook = new BookDAL();
            IUserDAL iUser = new UserDAL();
            bookShelf = new BookContainer(iBook);
            TransactionVal = new TransactionValidator(iBook, iUser);
        }



        // Lend Book
        private bool LendBook(int UserID, int BookID)
        {
            return bookShelf.LendBook(UserID, BookID);     
        }

        [HttpPost]
        public IActionResult LendBookResult(string userID, string bookID)
        {
            if (TransactionVal.ValidateUserID(userID) && TransactionVal.ValidateBookID(bookID))
            {
                 if (LendBook(Convert.ToInt32(userID), Convert.ToInt32(bookID)))
                {
                    return View("../Partial/Succes", "Het boek is uitgeleend! De inleverdatum is "+ DateTime.Now.AddDays(21).ToShortDateString() +"!");
                }
                else
                {
                    return View("../Partial/Error", "Dit boek is al uitgeleend, kies een ander boek."); 
                }
            }
            else
            {
                return View("../Partial/Error", TransactionVal.Result);
            }
        }




        // Return Book
        private bool ReturnBook(int UserID, int BookID)
        {
            return bookShelf.ReturnBook(UserID, BookID);
        }

        [HttpPost]
        public IActionResult ReturnBookResult(string userID, string bookID)
        {
            if (TransactionVal.ValidateUserID(userID) && TransactionVal.ValidateBookID(bookID))
            {
                if (!bookShelf.UserIDBookIDExists(Convert.ToInt32(userID), Convert.ToInt32(bookID)))
                {
                    return View("../Partial/Error", "Deze gebruiker heeft dit boek niet uitgeleend!");
                }
                else if (ReturnBook(Convert.ToInt32(userID), Convert.ToInt32(bookID)))
                {
                    return View("../Partial/Succes", "Het boek is ingeleverd!");
                }
                else
                {
                    return View("../Partial/Error", "Dit boek is al ingeleverd, kies een ander boek.");
                }
            }
            else
            {
                return View("../Partial/Error", TransactionVal.Result);
            }
        }




        //Prolong Book
        private bool ProlongBook(int userID, int bookID)
        {
            return bookShelf.ProlongBook(userID, bookID);
        }
      
        public IActionResult ProlongBookResult(int userID, int bookID)
        {
            if (ProlongBook(userID, bookID))
            {
                return View("../Partial/Succes", "Het boek is verlengd! de nieuwe datum is " + DateTime.Now.AddDays(21).ToShortDateString() +"!" );
            }
            else
            {
                return View("../Partial/Error", "Je hebt het boek al 3x verlengd!");
            }
        }
        
    }
}