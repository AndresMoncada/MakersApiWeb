using MakersApiWeb.App.DTOs;
using MakersApiWeb.Domain.Entities;
using MediatR;

namespace MakersApiWeb.App.Handlers.UserHandler.Params
{
    public class UserInsCommand : IRequest<UserDto>
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int RoleId { get; set; }
    }
}
