using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Wba.EE.DeMiddelaerBart.Domain.Models;
using static Wba.EE.DeMiddelaerBart.Web.DataServices;
using static Wba.EE.DeMiddelaerBart.Domain.SiteProperties;
using static Wba.EE.DeMiddelaerBart.Domain.EncryptionServise;
using Wba.EE.DeMiddelaerBart.Domain.DataAccess;
using Microsoft.AspNetCore.Http;
using Wba.EE.DeMiddelaerBart.Web.Models;
using System.Threading.Tasks;

namespace Wba.EE.DeMiddelaerBart.Web.Controllers
{
    public class LogInController : Controller
    {
        readonly SiteContext _dataBase;
        readonly HttpContext _curentHttpContent;

        public LogInController(SiteContext db, IHttpContextAccessor httpContextAccessor)
        {
            _dataBase = db;
            _curentHttpContent = httpContextAccessor.HttpContext;
        }

        public IActionResult LogOut()
        {          
            return LogoutUser(_curentHttpContent);
        }
        public IActionResult Members()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProssesLogIn(InputLogInViewModel input)
        {         
            // chaek for name && pass in database here
            foreach (var user in _dataBase.Users)
            {
                var userTryToLogIn = _dataBase.Users.ToList().Where(u => u.Name == input.UserName).FirstOrDefault();

                if (input.UserName == user.Name && HashAreEqual(input.PassWord, userTryToLogIn.Password, userTryToLogIn.PasswordSalt))
                {
                    // cookiee
                    SetUser(user, _curentHttpContent);
                    SetPlayDeck(user, _dataBase, _curentHttpContent);
                    return Redirect("~/Home/Index");
                }              
            }           
            return View(); //<-- bad login          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        async public Task<IActionResult> Registration(InputRegistration info)
        {           
            if (GetUser(_curentHttpContent) != null)
            {
                return Redirect("~/Home/Index");
            }
            else {

                if (_dataBase.Users.ToList().TrueForAll(user => user.Name != info.Username)) // kijkt of er al een gebruiker is met deze naam
                {
                    if (ModelState.IsValid)
                    {
                        var newUser = new User {
                            Name = info.Username,
                            PasswordSalt = CreateSalt(PasswordSaldLeght),
                            GenderId = info.GenderID,
                            DayOfBirth = info.Dob,
                            Country = info.Country,
                            Email = info.Email,
                            PhoneNumber = info.PhoneNumber,
                            Bio = info.Bio,
                            IndexOfTeamSelectit = info.IndexOfTeamSelectit,
                            IndexOfAvatarSelectit = info.IndexOfAvatarSelectit,
                            TypeOfUser = UserType.User,
                            HighScore = 0,
                            PlayDeck = new List<Pokemon>()
                        };

                        newUser.Password = GenerateHash(info.Password, newUser.PasswordSalt);

                       
                        SetUser(newUser, _curentHttpContent);
                        await _dataBase.AddAsync(newUser);
                        await _dataBase.SaveChangesAsync();

                        //----------------------------------------------------
                        return RedirectToAction(nameof(RegistrationSucces));
                    }
                }
                else ModelState.AddModelError("Username", "Username bestaat al");            
                return View(info);
            }
        }

        public IActionResult RegistrationSucces() => View();
        

        public IActionResult Leaderboard()
        {          
            return View();
        }

        public IActionResult ProfilOfMember(string userName) => View(
            _dataBase.Users.ToList().Where(u => u.Name == userName).FirstOrDefault()
        );
        
    }
}           