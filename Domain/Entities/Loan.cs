using MakersApiWeb.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakersApiWeb.Domain.Entities
{
    public class Loan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLoan { get; set; }
        public decimal Amount { get; set; }
        public DateTime RequestedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ApprovedDate { get; set; }
        public int TermInDays { get; set; }
        public LoanStatus Status { get; set; } = LoanStatus.Pending;

        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
