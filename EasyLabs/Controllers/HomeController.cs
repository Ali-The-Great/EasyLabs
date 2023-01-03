using DataLibrary.BusinessLogic;
using EasyLabs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EasyLabs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        UserDb DBUser = new UserDb();
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp([Bind] UserModel model)
        {
            if (ModelState.IsValid) 
            {
                if (DBUser.UserExists(model.mail)) 
                {                    
                    TempData["UserExists"] = "Another User with the same mail already exists";
                }
                else
                {
                    DBUser.InsertUser(EasyLabs.Models.UserModel.UTransform(model));
                    return RedirectToAction("ProfilePage", "User", new { model.mail });
                }                
            }            
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogIn([Bind] LogInModel model)
        {
            if (ModelState.IsValid)
            {
                if (DBUser.UserExists(model.mail))
                {
                    if (DBUser.CorrectPass(EasyLabs.Models.LogInModel.LITransform(model)))
                    {
                        //ProfileModel A = EasyLabs.Models.ProfileModel.PLTransform(DBUser.GetProfile(model.mail));
                        return RedirectToAction("ProfilePage","User",new { model.mail });
                    }
                    else 
                    {
                        TempData["IncorrectPassword"] = "Incorrect Password or email";
                    }
                    
                }
                else
                {
                    TempData["NoSuchUser"] = "this user doesn't exist";                    
                }
            }
            return View();
        }
    }
}