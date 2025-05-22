namespace MakersApiWeb.App.DTOs
{
    public class LoanDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int TermInDays { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; } = string.Empty;
    }
}
