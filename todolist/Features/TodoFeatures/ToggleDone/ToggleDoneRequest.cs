using MediatR;

namespace todolist.Features.TodoFeatures.ToggleDone
{
    public class ToggleDoneRequest : IRequest<ToggleDoneResponse>
    {
        public string Id { get; set; }
    }
}