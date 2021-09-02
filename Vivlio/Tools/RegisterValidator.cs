using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Vivlio.Containers;
using Vivlio.Interfaces;
using Vivlio.Models;

namespace Vivlio.Tools
{
    public class RegisterValidator
    {
        public string Result { get; private set; } = "";

        UserContainer userContainer;

        public RegisterValidator(IUserDAL userDAL)
        {
            userContainer = new UserContainer(userDAL);
        }



        public bool ValidateName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                Result = "Vul een naam in!";
                return false;
            }

            if (!OnlyLetters(name))
            {
                Result = "Je naam mag alleen letters bevatten";
                return false;
            }

            return true;
        }

        public bool ValidateUsername(string username, bool CheckDatabase)
        {
            if (String.IsNullOrEmpty(username))
            {
                Result = "Vul een gebruiksnaam in!";
                return false;
            }

            if (username.Length <= 4)
            {
                Result = "Je gebruiksnaam moet minstens 4 tekens bevatten";
                return false;
            }

            if (OnlyNumbers(username))
            {
                Result = "Je gebruiksnaam moet minstens 1 letter bevatten";
                return false;
            }

            if (CheckDatabase)
            {
                if (userContainer.UsernameExists(username))
                {
                    Result = "Deze gebruikersnaam bestaat al!";
                    return false;
                }
            }  
            
            return true;
        }

        public bool ValidateBirthdate(DateTime? birthDate)
        {
            if (birthDate == DateTime.MinValue || !birthDate.HasValue)
            {
                Result = "Vul een geboortedatum in!";
                return false;
            }
            if (birthDate > DateTime.Now.AddYears(-6))
            {
                Result = "Je moet minstens 6 jaar oud zijn!";
                return false;
            }
            if (birthDate < DateTime.Now.AddYears(-200) || birthDate> DateTime.Now.AddYears(200))
            {
                Result = "Vul een juiste geboortedatum in!";
                return false;
            }
            
            return true;
        }

        public bool ValidateUserFunction(string userFunction)
        {
            if (String.IsNullOrEmpty(userFunction))
            {
                Result = "Vul een functie in!";
                return false;
            }
            return true;
        }

        public bool ValidateEmail(string email)
        {

            if (String.IsNullOrEmpty(email))
            {
                Result = "Vul een email adres in!";
                return false;
            }

            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

            if (!regex.IsMatch(email))
            {
                Result = "Vul een juist email adress in!";
                return false;
            }

            return true;
        }

        public bool ValidatePassword(string password, string repeatPassword)
        {
            if (String.IsNullOrEmpty(password) || String.IsNullOrEmpty(repeatPassword))
            {
                Result = "Vul een wachtwoord in!";
                return false;
            }

            if (password != repeatPassword)
            {
                Result = "De wachtwoorden kom niet overheen!";
                return false;
            }

            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");
            if (!regex.IsMatch(password))
            {
                Result = "Het wachtwoord voldoet niet aan de eisen!";
                return false;
            }

            return true;
        }

        public bool ValidatePhoneNumber(string phonenumber)
        {
            
            if (!String.IsNullOrEmpty(phonenumber) && !OnlyNumbers(phonenumber))
            {
                Result = "Vul alleen getallen in!";
                return false;
            }
            if (!String.IsNullOrEmpty(phonenumber) && phonenumber.Length >10)
            {
                Result = "Je telefoonnummer is te lang, vul maximaal 10 getallen in!";
                return false;
            }

            return true;
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

        private bool OnlyLetters(string text)
        {
            Regex regex = new Regex(@"^[a-zA-Z]+$");
            if (regex.IsMatch(text))
            {
                return true;
            }
            return false;
        }
    }
}
