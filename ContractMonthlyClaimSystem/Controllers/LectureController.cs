using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using ContractMonthlyClaimSystem.Models;
using ContractMonthlyClaimSystem.Services;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class LectureController : Controller
    {
        private readonly ClaimService _claimService;

        public LectureController(ClaimService claimService)
        {
            _claimService = claimService;
        }

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
            string? filePath = null;
            if (SupportingDocument != null && SupportingDocument.Length > 0)
            {
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
    }
}


