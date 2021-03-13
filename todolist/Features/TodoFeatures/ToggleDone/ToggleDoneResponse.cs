using System;
using todolist.Models.Responses;

namespace todolist.Features.TodoFeatures.ToggleDone
{
    public class ToggleDoneResponse : ResponseBaseModel<DateTime>
    {
        public static ToggleDoneResponse GetSuccess(DateTime updated) => new ToggleDoneResponse()
        {
            Status = ResponseStatus.Success,
            Data = updated,
            Errors = null,
            Message = "Updated successfully!"
        };
    }
}