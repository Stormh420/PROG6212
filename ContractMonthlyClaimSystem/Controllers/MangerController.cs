using Microsoft.AspNetCore.Mvc;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class ManagerController : Controller
    {
        // Get main manager navigation page
        public IActionResult MainManager()
        {
            return View();
        }

        // Get pending claims view
        public IActionResult PendingClaims()
        {
            return View();
        }

        // Get all the claims view 
        public IActionResult ViewAllClaims()
        {
            return View();
        }
    }
}

