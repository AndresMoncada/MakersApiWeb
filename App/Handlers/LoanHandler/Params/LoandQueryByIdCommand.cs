using MakersApiWeb.App.DTOs;
using MediatR;

namespace MakersApiWeb.App.Handlers.LoanHandler.Params
{
    public class LoandQueryByIdCommand : IRequest<LoanDto>
    {
        public int IdLoan { get; set; }
    }
}
