using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vivlio.Containers;
using Vivlio.DAL_s;
using Vivlio.Models;
using Vivlio.Interfaces;
using Vivlio.Tools;
using Vivlio.Enum_s;

namespace Vivlio.Controllers
{
    public class AccountController : Controller
    {
        User user;

        UserContainer Users;
        BookContainer bookShelf;

        RegisterValidator RegisterVal;
        TransactionValidator TransactionVal;


        public AccountController()
        {
            IUserDAL iUser = new UserDAL();
            IBookDAL iBook = new BookDAL();

            user = UserController.user;
            Users = new UserContainer(iUser);
            bookShelf = new BookContainer(iBook);
            RegisterVal = new RegisterValidator(iUser);
            TransactionVal = new TransactionValidator(iBook, iUser);
        }



        //Change account Info
        public IActionResult ChangeAccountInfoView()
        {
            if (user == null)
            {
                ModelState.AddModelError("Alert", "Log eerst in!");
                return View("../Login/Index");
            }

            return View("../ChangeAccountInfo/Index");
        }

        public IActionResult ChangeAccountInfo(string name, string username, string email, string phonenumber)
        {
            if (!RegisterVal.ValidateName(name) || !RegisterVal.ValidateUsername(username, false) || !RegisterVal.ValidateEmail(email) || !RegisterVal.ValidatePhoneNumber(phonenumber))
            {
                ModelState.AddModelError("Alert", RegisterVal.Result);
                return View("../ChangeAccountInfo/Index");
            }
            else
            {
                if (Users.UpdateUser(user.ID, name, username, email, phonenumber))
                {
                    user.Name = name;
                    user.Username = username;
                    user.Email = email;
                    user.Phonenumber = phonenumber;

                    ModelState.AddModelError("Succes", "Je gegevens zijn succesvol aangepast!");
                    return View("../Profile/Index", user);
                }

                ModelState.AddModelError("Alert", "Er ging wat mis");
                return View("../ChangeAccountInfo/Index");
            }
        }

        public IActionResult ChangeAccountPassword(string password, string repeatPassword)
        {

            if (!RegisterVal.ValidatePassword(password, repeatPassword))
            {
                ModelState.AddModelError("Alert", RegisterVal.Result);
                return View("../ChangeAccountInfo/Index");
            }
            else
            {
                if (Users.UpdatePassword(user.ID, password))
                {
                    ModelState.AddModelError("Succes", "Je wachtwoord is succesvol aangepast!");
                    return View("../Profile/Index", user);
                }

                ModelState.AddModelError("Alert", "Er ging wat mis");
                return View("../ChangeAccountInfo/Index");
            }
        }



        // Change User Function
        public IActionResult ChangeUserFunctionView()
        {
            if (user == null)
            {
                ModelState.AddModelError("Alert", "Log eerst in!");
                return View("../Login/Index");
            }
            if (user.UserFunction != UserFunction.Admin)
            {
                ModelState.AddModelError("Alert", "Je hebt hier geen rechten voor!");
                return View("../Home/Index", bookShelf.GetBooks());
            }

            return View("../ChangeUserFunction/Index", Users.GetUsers());
        }

        public IActionResult ChangeUserFunction(string userID)
        {
            string userFunction = Request.Form["userFunction"].ToString();

            UserFunction function = (UserFunction)Enum.Parse(typeof(UserFunction), userFunction);

            if (TransactionVal.ValidateUserID(userID))
            {
                if (Users.UpdateUserFunction(Convert.ToInt32(userID), function))
                {
                    return View("../Partial/Succes", "De medewerker is nu " + function.ToString() + "!");
                }
                else
                {
                    return View("../Partial/Error", "Er ging iets mis, probeer het later nog een keer");
                }
            }
            else
            {
                return View("../Partial/Error", TransactionVal.Result);
            }
        }

    }
}