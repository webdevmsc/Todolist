using MediatR;
using todolist.Models.Responses;

namespace todolist.Features.TodoFeatures.ToggleDone
{
    public class ToggleDoneResponse : ResponseBaseModel<Unit?>
    {
        public static ToggleDoneResponse GetSuccess() => new ToggleDoneResponse()
        {
            Status = ResponseStatus.Success,
            Data = null,
            Errors = null,
            Message = "Updated successfully!"
        };
    }
}