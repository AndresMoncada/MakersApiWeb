using AutoMapper;
using MakersApiWeb.App.DTOs;
using MakersApiWeb.App.Handlers.UserHandler.Params;
using MakersApiWeb.Domain.Entities;
using MakersApiWeb.Infraestructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MakersApiWeb.App.Handlers.UserHandler.Create
{
    public sealed class UserInsCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<UserInsCommand, UserDto>
    {
        public async Task<UserDto> Handle(UserInsCommand request, CancellationToken cancellationToken)
        {
            return await CreateUser(request, cancellationToken);
        }

        public async Task<UserDto> CreateUser(UserInsCommand request, CancellationToken cancellationToken)
        {
            using var transaccion = await context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var roleForUser = await context.Roles.FirstOrDefaultAsync(r => r.IdRole == request.RoleId, cancellationToken: cancellationToken)
                    ?? throw new InvalidOperationException("Role doesnt exists.");

                var user = new User
                {
                    FullName = request.FullName,
                    Email = request.Email,
                    RoleId = request.RoleId,
                    Role = roleForUser,
                    IsActive = true
                };

                context.Users.Add(user);
                await context.SaveChangesAsync(cancellationToken);
                await transaccion.CommitAsync(cancellationToken);

                return mapper.Map<UserDto>(user);
            }
            catch (Exception ex)
            {
                await transaccion.RollbackAsync(cancellationToken);
                throw new Exception("Error creating user " + ex.Message, ex);
            }
        }
    }
}
