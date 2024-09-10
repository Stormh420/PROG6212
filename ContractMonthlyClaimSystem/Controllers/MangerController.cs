using Microsoft.AspNetCore.Mvc;
using ContractMonthlyClaimSystem.Services;
using ContractMonthlyClaimSystem.Models;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ClaimService _claimService;

        public ManagerController(ClaimService claimService)
        {
            _claimService = claimService;
        }

        // Approve the claim
        public IActionResult ApproveClaim(int ClaimId)
        {
            _claimService.UpdateClaimStatus(ClaimId, ClaimStatus.Approved);
            return RedirectToAction("PendingClaims");
        }

        // Deny the claim
        public IActionResult DenyClaim(int ClaimId)
        {
            _claimService.UpdateClaimStatus(ClaimId, ClaimStatus.Denied);
            return RedirectToAction("PendingClaims");
        }

        // Get the pending claims view
        public IActionResult PendingClaims()
        {
            var claims = _claimService.GetAllClaims().Where(c => c.Status == ClaimStatus.Pending).ToList();
            return View("~/Views/Manger/PendingClaims.cshtml", claims);
        }

        // Get the view for all claims
        public IActionResult ViewAllClaims()
        {
            var claims = _claimService.GetAllClaims();
            return View("~/Views/Manger/ViewAllClaimsManger.cshtml", claims);
        }
    }
}



