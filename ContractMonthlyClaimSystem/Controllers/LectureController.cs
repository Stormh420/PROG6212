using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class LectureController : Controller
    {
        // Get the submit claims view
        public IActionResult SubmitClaims()
        {
            return View("~/Views/Lecture/SubmitClaim.cshtml");
        }

        // Handle the form submission
        [HttpPost]
        public async Task<IActionResult> SubmitClaims(string LectureName, int HoursWorked, decimal HourlyRate, string Notes, IFormFile SupportingDocument)
        {
            // Calculate total
            decimal total = HoursWorked * HourlyRate;

            // Handle file upload
            if (SupportingDocument != null && SupportingDocument.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", SupportingDocument.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await SupportingDocument.CopyToAsync(stream);
                }
            }

            // TODO: Save the claim data (LectureName, HoursWorked, HourlyRate, total, Notes, file path) to the database

            // Redirect to confirmation or claims list page
            return RedirectToAction("ViewAllClaimLecture");
        }

        // Get the view all claims view
        public IActionResult ViewAllClaimLecture()
        {
            return View("~/Views/Lecture/ViewAllClaimLecture.cshtml");
        }
    }
}

