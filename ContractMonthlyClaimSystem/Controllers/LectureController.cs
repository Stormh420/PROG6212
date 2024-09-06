using Microsoft.AspNetCore.Mvc;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class LectureController : Controller
    {
        // Get submit claims view
        public IActionResult SubmitClaims()
        {
            return View("~/Views/Lecture/SubmitClaim.cshtml");
        }

        // Get the view all the claims view 
        public IActionResult ViewAllClaimLecture()
        {
            return View("~/Views/Lecture/ViewAllClaimLecture.cshtml");
        }
    }
}
