using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using ContractMonthlyClaimSystem.Models;
using ContractMonthlyClaimSystem.Services;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class LectureController(ClaimService claimService) : Controller
    {
        private readonly ClaimService _claimService = claimService;

        // Get the submit claims view
        public IActionResult SubmitClaims()
        {
            return View("~/Views/Lecture/SubmitClaim.cshtml");
        }

        // Handle the form submission
        [HttpPost]
        public async Task<IActionResult> SubmitClaims(string LectureName, int HoursWorked, decimal HourlyRate, string Notes, IFormFile SupportingDocument)
        {
            // Set file size limit (5MB in this example)
            long fileSizeLimit = 5 * 1024 * 1024;

            // Calculate total
            decimal total = HoursWorked * HourlyRate;

            // Handle file upload
            string? filePath = null;
            if (SupportingDocument != null && SupportingDocument.Length > 0)
            {
                if (SupportingDocument.Length > fileSizeLimit)
                {
                    // Return an error if file exceeds the size limit
                    ModelState.AddModelError("File", "The uploaded file exceeds the allowed size of 5MB.");
                    return View("~/Views/Lecture/SubmitClaim.cshtml"); // Return to the form with an error message
                }

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                Directory.CreateDirectory(uploadsFolder); // Ensure directory exists
                filePath = Path.Combine(uploadsFolder, SupportingDocument.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await SupportingDocument.CopyToAsync(stream);
                }
            }

            // Create a new claim
            var claim = new Claim
            {
                LectureName = LectureName,
                HoursWorked = HoursWorked,
                HourlyRate = HourlyRate,
                Notes = Notes,
                SupportingDocumentPath = filePath,
                DateSubmitted = DateTime.Now, // Current date and time
                Status = ClaimStatus.Pending // Default status is Pending
            };

            // Save the claim using the service (stores in memory or database)
            _claimService.AddClaim(claim);

            // Redirect to the list of claims
            return RedirectToAction("ViewAllClaimLecture");
        }


        // Get the view all claims view
        public IActionResult ViewAllClaimLecture()
        {
            var claims = _claimService.GetAllClaims();
            return View(claims); // Pass claims data to the view
        }

        // New Action to view a single claim's details
        [HttpPost]
        public IActionResult ViewClaim(int ClaimId)
        {
            // Fetch the claim by ID
            var claim = _claimService.GetAllClaims().FirstOrDefault(c => c.ClaimId == ClaimId);

            // Check if the claim exists
            if (claim == null)
            {
                return NotFound();
            }

            // Pass the claim to the view
            return View("~/Views/Lecture/ViewClaimDetails.cshtml", claim);
        }



    }
}



