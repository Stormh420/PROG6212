using System.Collections.Generic;
using System.Linq;
using ContractMonthlyClaimSystem.Models;

namespace ContractMonthlyClaimSystem.Services
{
    public class ClaimService
    {
        private readonly List<Claim> _claims = new List<Claim>();
        private int _nextClaimId = 1; // Simple ID generation

        // Add a new claim
        public void AddClaim(Claim claim)
        {
            claim.ClaimId = _nextClaimId++;
            claim.DateSubmitted = DateTime.Now;
            claim.Status = ClaimStatus.Pending; // Default status is pending
            _claims.Add(claim);
        }

        // Get all claims
        public List<Claim> GetAllClaims()
        {
            return _claims;
        }

        // Update the status of a claim
        public void UpdateClaimStatus(int claimId, ClaimStatus status)
        {
            var claim = _claims.FirstOrDefault(c => c.ClaimId == claimId);
            if (claim != null)
            {
                claim.Status = status;
            }
        }
    }
}

