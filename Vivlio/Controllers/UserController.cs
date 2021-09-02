using Microsoft.AspNetCore.Mvc;
using Vivlio.Containers;
using Vivlio.DAL_s;
using Vivlio.Models;
using Vivlio.Tools;
using Vivlio.Enum_s;
using System;
using System.Data;
using Vivlio.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vivlio.Controllers
{
    public class UserController : Controller
    {
        //User
        public static User user { get; private set; }

        // Containers
        UserContainer Users;
        BookContainer bookShelf;

        //Validators
        TransactionValidator TransactionVal;
        LoginValidator LoginVal;
        RegisterValidator RegisterVal;

        public UserController()
        {
            IUserDAL iUser = new UserDAL();
            IBookDAL iBook = new BookDAL();
            Users = new UserContainer(iUser);
            bookShelf = new BookContainer(iBook);
            TransactionVal = new TransactionValidator(iBook, iUser);
            LoginVal = new LoginValidator(iUser);
            RegisterVal = new RegisterValidator(iUser);
        }


        
        public IActionResult HomeView()
        {
            if (user == null)
            {
                ModelState.AddModelError("Alert", "Log eerst in!");
                return View("../Login/Index");
            }

            return View("../Home/Index",bookShelf.GetBooks());
        }

        public IActionResult ReturnBookView()
        {
            if (user == null)
            {
                ModelState.AddModelError("Alert", "Log eerst in!");
                return View("../Login/Index");
            }
            if (user.UserFunction == UserFunction.Member)
            {
                ModelState.AddModelError("Alert", "Je hebt hier geen rechten voor!");
                return View("../Home/Index",bookShelf.GetBooks());
            }

            ViewData["bookTable"] = bookShelf.GetBooks();
            return View("../ReturnBook/Index", Users.GetUsers());
            
        }

        public IActionResult LendBookView()
        {
            if (user == null)
            {
                ModelState.AddModelError("Alert", "Log eerst in!");
                return View("../Login/Index");
            }
            if (user.UserFunction == UserFunction.Member)
            {
                ModelState.AddModelError("Alert", "Je hebt hier geen rechten voor!");
                return View("../Home/Index", bookShelf.GetBooks());
            }

            ViewData["bookTable"] = bookShelf.GetBooks();
            return View("../LendBook/Index", Users.GetUsers());
        }

        public IActionResult LoginView()
        {
            user = null;
            return View("../Login/Index");
        }

        public IActionResult RegisterView()
        {
            return View("../Register/Index");
        }

        public IActionResult ProfileView()
        {
            if (user == null)
            {
                ModelState.AddModelError("Alert", "Log eerst in!");
                return View("../Login/Index");
            }
            return View("../Profile/Index", user);
        }

        public IActionResult CatalogueView()
        {
            ViewData["PopulairBooks"] = bookShelf.GetPopulairBooks();

            DataTable dataTable = bookShelf.GetBooks();
            DataView dv = dataTable.DefaultView;
            dv.Sort = "Titel";
            dataTable = dv.ToTable();

            return View("../Catalogue/Index", dataTable); ;
        }



        public IActionResult Login(string Username, string Password)
        {
            //Username = "jensevent";
            //Password = "Welkom12345";

            if (LoginVal.ValidateUsername(Username) && LoginVal.ValidatePassword(Password))
            {
                if (Users.Login(Username, Password))
                {
                    user = Users.GetUserByUsername(Username);

                    ModelState.AddModelError("Succes", "Je bent ingelogd!");
                    return View("../Home/Index",bookShelf.GetBooks());
                }
                else
                {
                    ModelState.AddModelError("Alert", "Wachtwoord en gebruikersnaam komen niet overeen!");
                    return View("../Login/Index");
                }
            }
            else
            {
                ModelState.AddModelError("Alert", LoginVal.Result);
                return View("../Login/Index");
            }
        }
        
        public IActionResult Register(string name, string username, DateTime birthdate, string email,string phonenumber, string password, string repeatPassword)
        {
            string userFuction = "Member";

            if (!RegisterVal.ValidateName(name) || !RegisterVal.ValidateUsername(username,true) || !RegisterVal.ValidateBirthdate(birthdate) || !RegisterVal.ValidateEmail(email) || !RegisterVal.ValidateUserFunction(userFuction) || !RegisterVal.ValidatePhoneNumber(phonenumber) ||!RegisterVal.ValidatePassword(password, repeatPassword))
            {
                ModelState.AddModelError("Alert", RegisterVal.Result);
                return View("../Register/Index");
            }
            else
            {
                if(Users.CreateUser(name, username, birthdate, userFuction, email, phonenumber, password))
                {
                    user = Users.GetUserByUsername(username);

                    ModelState.AddModelError("Succes", "Je account is succesvol aangemaakt, je bent ingelogd!");
                    return View("../Home/Index",bookShelf.GetBooks());
                }
                ModelState.AddModelError("Alert", "Er ging iets mis");
                return View("../Register/Index");
            } 
        }    
    }
}
