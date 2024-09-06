using Microsoft.AspNetCore.Mvc;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // GET: Account/Register
        public IActionResult Register()
        {
            return View();
        }

        //Get: Manger/MainManger
        public IActionResult MainManger() 
        { 
            return View("~/Views/Manger/MainManger.cshtml");
        }

        public IActionResult MainLecture() 
        {
            return View("~/Views/Lecture/MainLecture.cshtml");
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Validate the credentials (this is just an example, use proper validation in production)
            if (IsValidUser(username, password))
            {
                // Redirect to another page or action
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Return the view with an error message
                ViewBag.ErrorMessage = "Invalid username or password";
                return View();
            }
        }

        private bool IsValidUser(string username, string password)
        {
            // Example validation logic (replace with real authentication)
            return username == "admin" && password == "password";
        }
    }
}


