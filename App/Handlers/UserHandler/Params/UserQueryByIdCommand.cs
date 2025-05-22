using MakersApiWeb.App.DTOs;
using MakersApiWeb.Domain.Entities;
using MediatR;

namespace MakersApiWeb.App.Handlers.UserHandler.Params
{
    public class UserQueryByIdCommand : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}
