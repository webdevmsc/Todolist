using System.Collections.Generic;
using todolist.Features.TodoFeatures.AddNewTodoItem;
using todolist.Models.Responses;
using todolist.Models.Todo;

namespace todolist.Features.TodoFeatures.GetAll
{
    public class GetAllResponse : PagedResponseBaseModel<List<TodoItem>>
    {
        public static GetAllResponse GetSuccess(List<TodoItem> todos, int total) => new GetAllResponse()
        {
            Status = ResponseStatus.Success,
            Data = todos,
            Errors = null,
            Message = null,
            Total = total
        };
    }
}