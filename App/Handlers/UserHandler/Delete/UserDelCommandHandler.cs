
using MakersApiWeb.App.Handlers.UserHandler.Params;
using MakersApiWeb.Infraestructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MakersApiWeb.App.Handlers.UserHandler.Delete
{

    public sealed class UserDelCommandHandler(AppDbContext context) : IRequestHandler<UserDelCommand, bool>
    {
        public async Task<bool> Handle(UserDelCommand request, CancellationToken cancellationToken)
        {
            return await DeleteUser(request, cancellationToken);
        }

        public async Task<bool> DeleteUser(UserDelCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FirstOrDefaultAsync(r => r.IdUser == request.Id) ?? throw new Exception("User doesnt exists.");
            context.Users.Remove(user);
            await context.SaveChangesAsync(cancellationToken);

            return true;
        }

    }
}

