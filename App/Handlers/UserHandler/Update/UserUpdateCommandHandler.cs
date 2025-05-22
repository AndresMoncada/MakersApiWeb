
using MakersApiWeb.App.Handlers.UserHandler.Params;
using MakersApiWeb.Infraestructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MakersApiWeb.App.Handlers.UserHandler.Update
{

    public sealed class UserUpdateCommandHandler(AppDbContext context) : IRequestHandler<UserUpdateCommand, bool>
    {
        public async Task<bool> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            return await UpdateUser(request, cancellationToken);
        }

        public async Task<bool> UpdateUser(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            using var transaccion = await context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var user = await context.Users.SingleOrDefaultAsync(u => u.IdUser == request.IdUser, cancellationToken) ?? throw new Exception("User doesnt exists.");

                user.FullName = request.FullName;
                user.Email = request.Email;

                await context.SaveChangesAsync(cancellationToken);
                await transaccion.CommitAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                await transaccion.RollbackAsync(cancellationToken);
                throw new Exception("Error updating user " + ex.Message, ex);
            }
        }

    }
}
