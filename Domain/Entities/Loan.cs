using MakersApiWeb.Domain.Enums;

namespace MakersApiWeb.Domain.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime RequestedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ApprovedDate { get; set; }

        public LoanStatus Status { get; set; } = LoanStatus.Pending;

        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
