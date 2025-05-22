using MediatR;

namespace MakersApiWeb.App.Handlers.UserHandler.Params
{
    public class UserDelCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
