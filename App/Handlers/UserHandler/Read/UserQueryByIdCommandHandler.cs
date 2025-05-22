using AutoMapper;
using MakersApiWeb.App.DTOs;
using MakersApiWeb.App.Handlers.UserHandler.Params;
using MakersApiWeb.Infraestructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MakersApiWeb.App.Handlers.UserHandler.Read
{

    public sealed class UserQueryByIdCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<UserQueryByIdCommand, UserDto>
    {
        public async Task<UserDto> Handle(UserQueryByIdCommand request, CancellationToken cancellationToken)
        {
            return await QueryUser(request, cancellationToken);
        }

        public async Task<UserDto> QueryUser(UserQueryByIdCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.SingleOrDefaultAsync(u => u.IdUser == request.Id, cancellationToken);
            var mappingUser = mapper.Map<UserDto>(user);

            return mappingUser ?? throw new Exception("User doesnt exists.");
        }
    }
}
