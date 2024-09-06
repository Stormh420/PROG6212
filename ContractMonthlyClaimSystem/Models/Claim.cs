namespace ContractMonthlyClaimSystem.Models
{
    public class Claim
    {
        public int ClaimId { get; set; } // Unique claim ID
        public required string LectureName { get; set; }
        public int HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal Total => HoursWorked * HourlyRate; // Automatically calculates total
        public string? Notes { get; set; }
        public string? SupportingDocumentPath { get; set; } // Path to the uploaded file
        public DateTime DateSubmitted { get; set; } // Date and time the claim was submitted
        public ClaimStatus Status { get; set; } // Status of the claim (Pending, Approved, Denied)
    }

    // Enum to represent claim statuses
    public enum ClaimStatus
    {
        Pending,
        Approved,
        Denied
    }
}

