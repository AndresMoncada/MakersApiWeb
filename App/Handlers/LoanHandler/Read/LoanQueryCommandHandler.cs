using AutoMapper;
using MakersApiWeb.App.DTOs;
using MakersApiWeb.App.Handlers.LoanHandler.Params;
using MakersApiWeb.Infraestructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MakersApiWeb.App.Handlers.LoanHandler.Read
{
    public class LoanQueryCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<LoandQueryByIdCommand, LoanDto>
    {
        public async Task<LoanDto> Handle(LoandQueryByIdCommand request, CancellationToken cancellationToken)
        {
            var loan = await context.Loans
                .Include(l => l.User)
                .FirstOrDefaultAsync(l => l.IdLoan == request.IdLoan, cancellationToken) ?? throw new Exception("Loan not found");

            return mapper.Map<LoanDto>(loan);
        }
    }
}
