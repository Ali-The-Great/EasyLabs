using Datalibrary.BusinessLogic;
using Datalibrary.DataAccess;
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
            /*var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Appsettings.json");
            IConfiguration configuration = builder.Build();
            string constring = configuration.GetValue<string>("ConnectionStrings:LabDB");*/
            //var k = UserProcessor.GetHash("senfieldsdfgjuftgfdcjct");
            //Console.WriteLine(k);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        
        //UserDb dbu=new UserDb();
        
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
                    //dbu.InsertUser(UserModel.UModelTransform(model));
                    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Appsettings.json");
                    IConfiguration configuration = builder.Build();
                    UserProcessor Up = new UserProcessor(new SqlDataAccess(configuration));
                    Up.CreateUser(
                    model.Email,
                    model.Password);
                    if (model.EmpOrNot == true) 
                    {
                    Up.CreateEmp(
                        model.Name,
                        model.Email,
                        model.Gender,
                        model.phone_number,
                        model.birth_date);
                        
                    return RedirectToAction("Index");

                    }
                    Up.CreateClient(
                        model.Name,
                        model.Email,
                        model.Gender,
                        model.phone_number,
                        model.birth_date);
                return RedirectToAction("Privacy");
                }            
                return View();
        }

        public IActionResult EmpSignUp() 
        {
            return View();
        }
        public IActionResult ClientSignUp()
        {
            return View();
        }

    }
}