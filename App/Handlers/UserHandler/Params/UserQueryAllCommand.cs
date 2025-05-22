using MakersApiWeb.App.DTOs;
using MediatR;

namespace MakersApiWeb.App.Handlers.UserHandler.Params
{
    public class UserQueryAllCommand : IRequest<List<UserDto>>
    {
    }
}
