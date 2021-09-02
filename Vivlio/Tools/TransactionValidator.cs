using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Vivlio.Containers;
using Vivlio.DAL_s;
using Vivlio.Interfaces;

namespace Vivlio.Tools
{
    public class TransactionValidator
    {
        BookContainer bookContainer;
        UserContainer userContainer;

        public string Result { get; private set; } = "";



        public TransactionValidator(IBookDAL iBook, IUserDAL iUser)
        {
            bookContainer = new BookContainer(iBook);
            userContainer = new UserContainer(iUser);
        }



        public bool ValidateUserID(string userID)
        {
            if(String.IsNullOrEmpty(userID))
            {
                Result = "Vul een gebruikersID in!";
                return false;
            }

            if (!OnlyNumbers(userID))
            {
                Result = "Vul een nummer in!";
                return false;
            }
            else
            {
                int IntID = Convert.ToInt32(userID);

                if (!UserIDExists(IntID))
                {
                    Result = "Deze gebruiker bestaat niet!";
                    return false;
                }
            }
            return true;
        }

        public bool ValidateBookID(string bookID)
        {
            if (String.IsNullOrEmpty(bookID))
            {
                Result = "Vul een BoekID in!";
                return false;
            }

            if (!OnlyNumbers(bookID))
            {
                Result = "Vul een nummer in!";
                return false;
            }
            else
            {
                int IntID = Convert.ToInt32(bookID);

                if (!BookIDExists(IntID))
                {
                    Result = "Dit boek bestaat niet!";
                    return false;
                }
            }
            return true;
        }



        private bool UserIDExists(int userID)
        {
            return userContainer.UserIDExists(userID);
        }

        private bool BookIDExists(int bookID)
        {
            return bookContainer.BookIDExists(bookID);
        }



        private bool OnlyNumbers(string text)
        {
            Regex regex = new Regex("^[0-9]+$");
            if (regex.IsMatch(text))
            {
                return true;
            }
            return false;
        }
        
    }
}
