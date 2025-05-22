using AutoMapper;
using MakersApiWeb.App.DTOs;
using MakersApiWeb.App.Handlers.UserHandler.Params;
using MakersApiWeb.Domain.Entities;
using MakersApiWeb.Infraestructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MakersApiWeb.App.Handlers.UserHandler.Read
{

    public sealed class UserQueryCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<UserQueryAllCommand, List<UserDto>>
    {
        public async Task<List<UserDto>> Handle(UserQueryAllCommand request, CancellationToken cancellationToken)
        {
            return await QueryUsers(request, cancellationToken);
        }

        public async Task<List<UserDto>> QueryUsers(UserQueryAllCommand request, CancellationToken cancellationToken)
        {
            var users = await context.Users.ToListAsync(cancellationToken: cancellationToken);
            var mappingUser = mapper.Map<List<UserDto>>(users);
            return mappingUser;
        }

    }
}
