using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Vivlio.Containers;
using Vivlio.Interfaces;

namespace Vivlio.Tools
{
    public class LoginValidator
    {
        UserContainer userContainer;
        public string Result { get; private set; } = "";

       
        public LoginValidator(IUserDAL userDAL)
        {
            userContainer = new UserContainer(userDAL);
        }



        public bool ValidateUsername(string username)
        {
            if (String.IsNullOrEmpty(username))
            {
                Result = "Vul een gebruikersnaam in!";
                return false;
            }

            if (!UsernameExists(username))
            {
                Result = "Deze gebruikersnaam bestaat niet!";
                return false;
            }
            return true;
        }

        public bool ValidatePassword(string password)
        {
            if(String.IsNullOrEmpty(password))
            {
                Result = "Vul een wachtwoord in!";
                return false;
            }
            return true;
        }

        private bool UsernameExists(string username)
        {
            return userContainer.UsernameExists(username);
        }
    }
}
