using System;
using todolist.Models.Responses;

namespace todolist.Features.TodoFeatures.ToggleDone
{
    public class ToggleDoneResponse : ResponseBaseModel<string>
    {
        public static ToggleDoneResponse GetSuccess(string updated) => new ToggleDoneResponse()
        {
            Status = ResponseStatus.Success,
            Data = updated,
            Errors = null,
            Message = "Updated successfully!"
        };
    }
}