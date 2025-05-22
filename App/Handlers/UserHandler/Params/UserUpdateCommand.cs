using MediatR;

namespace MakersApiWeb.App.Handlers.UserHandler.Params
{
    public class UserUpdateCommand : IRequest<bool>
    {
        public int IdUser { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
    }
}
