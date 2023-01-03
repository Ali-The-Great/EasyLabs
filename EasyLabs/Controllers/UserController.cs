using DataLibrary.BusinessLogic;
using EasyLabs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Reflection;

namespace EasyLabs.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public static class GlobalVariables
        {
            public static string Value { get; set; }
        }

        UserDb DBUser=new UserDb();
        public IActionResult ProfilePage(string mail)
        {
            GlobalVariables.Value = mail;
            ProfileModel A = EasyLabs.Models.ProfileModel.PLTransform(DBUser.GetProfile(mail));            
            return View(A);            
        }

        public IActionResult AppointmentPage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AppointmentPage([Bind] AppointmentModel model)
        {
            if (ModelState.IsValid) 
            {
                CultureInfo cultureInfo = new CultureInfo("en-US");
                TextInfo textInfo = cultureInfo.TextInfo;
                model.Test_Type = textInfo.ToTitleCase(model.Test_Type);               
                if(model.Test_Type == "Bloodwork" || model.Test_Type == "Urinalysis") 
                {
                    DateOnly date = DateOnly.FromDateTime(model.Date);
                    TimeOnly time = TimeOnly.FromDateTime(model.Date);
                    DBUser.Appoint(GlobalVariables.Value,model.Test_Type,date,time);

                }
                else 
                {
                    TempData["InvalidTest"] = "The Test should either be Bloodwork or Urinalysis";
                }
            }
            return View();
        }

    }
}
