using AutoMapper;
using MakersApiWeb.App.DTOs;
using MakersApiWeb.App.Handlers.LoanHandler.Params;
using MakersApiWeb.Domain.Entities;
using MakersApiWeb.Domain.Enums;
using MakersApiWeb.Infraestructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MakersApiWeb.App.Handlers.LoanHandler.Create
{
    public class LoanInsCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<LoanInsCommand, LoanDto>
    {
        public async Task<LoanDto> Handle(LoanInsCommand request, CancellationToken cancellationToken)
        {
            using var transaccion = await context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.IdUser == request.UserId, cancellationToken)
                ?? throw new InvalidOperationException("El usuario no existe.");

                var loan = new Loan
                {
                    Amount = request.Amount,
                    RequestedDate = DateTime.UtcNow,
                    TermInDays = request.TermInDays,
                    Status = LoanStatus.Pending,
                    UserId = request.UserId,
                    User = user
                };

                context.Loans.Add(loan);
                await context.SaveChangesAsync(cancellationToken);
                await transaccion.CommitAsync(cancellationToken);

                return mapper.Map<LoanDto>(loan);
            }
            catch (Exception ex)
            {
                await transaccion.RollbackAsync(cancellationToken);
                throw new Exception("Error al crear el usuario: " + ex.Message, ex);
            }
        }
    }
}
