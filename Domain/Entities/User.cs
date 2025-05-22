using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakersApiWeb.Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUser { get; set; }
        public string? FullName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;

        public int RoleId { get; set; }
        public required Role Role { get; set; }
        public bool IsActive { get; set; } = true;

        // Relación uno a muchos
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
