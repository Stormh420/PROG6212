using Microsoft.AspNetCore.Mvc;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class ManagerController : Controller
    {

        // Get pending claims view
        public IActionResult PendingClaims()
        {
            return View("~/Views/Manger/PendingClaims.cshtml");
        }

        // Get all the claims view 
        public IActionResult ViewAllClaims()
        {
            return View("~/Views/Manger/ViewAllClaimsManger.cshtml");
        }
    }
}

