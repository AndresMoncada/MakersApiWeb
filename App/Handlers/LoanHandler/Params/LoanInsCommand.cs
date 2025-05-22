using MakersApiWeb.App.DTOs;
using MediatR;

namespace MakersApiWeb.App.Handlers.LoanHandler.Params
{
    public class LoanInsCommand : IRequest<LoanDto>
    {
        public decimal Amount { get; set; }
        public int TermInDays { get; set; }
        public int UserId { get; set; }
    }
}
